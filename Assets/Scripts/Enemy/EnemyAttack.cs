using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float distanceForFollow;
    public float distanceForAttack;
    public float speed;
    public bool lookRight;

    private Transform player;
    private Vector3 startPos;
    private SpriteRenderer spriteRenderer;

    private void Start () {
        player = GameObject.FindWithTag ("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer> ();
        startPos = transform.position;
    }

    private void Update () {
        var newTarget = new Vector3(player.position.x, transform.position.y, transform.position.z);
        var distance = Vector3.Distance (transform.position, newTarget);

        if (distance <= distanceForAttack) {
            // ATACAR PLAYER   
        } else if (distance <= distanceForFollow) {
            // SEGUIR PLAYER


            if (transform.position.x > player.position.x && lookRight || transform.position.x < player.position.x && !lookRight) {
                lookRight = !lookRight;
                spriteRenderer.flipX = lookRight;
            }


            transform.position = Vector2.MoveTowards (transform.position, newTarget, speed * Time.deltaTime);

        } else if (distance > distanceForFollow) {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
    }
}