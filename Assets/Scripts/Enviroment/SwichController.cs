using UnityEngine;

public class SwichController : MonoBehaviour {

    public Transform elevator;
    public Transform A, B;
    public float speed;

    public Sprite[] sprites;

    private bool onOff = false;
    private Vector3 target;
    private SpriteRenderer spriteRenderer;

    private void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();

        target = A.position;
    }

    private void Update () {
        elevator.position = Vector3.MoveTowards (elevator.position, target, speed * Time.deltaTime);

        if (Input.GetMouseButtonDown (0))
            OnOff ();
    }

    private void OnTriggerEnter2D (Collider2D other) {

        var shoot = other.GetComponent<ShotMovement> ();

        if (shoot != null) {
            onOff = !onOff;

            if (onOff) {
                spriteRenderer.sprite = sprites[1];
                target = B.position;
            } else {
                spriteRenderer.sprite = sprites[0];
                target = A.position;
            }

            Destroy(other.gameObject);
        }
    }

    private void OnOff () {
        onOff = !onOff;

        if (onOff) {
            spriteRenderer.sprite = sprites[1];
            target = B.position;
        } else {
            spriteRenderer.sprite = sprites[0];
            target = A.position;
        }
    }
}