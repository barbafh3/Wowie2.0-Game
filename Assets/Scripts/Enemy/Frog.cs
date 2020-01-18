using UnityEngine;

public class Frog : EnemyBase {

    public float strong;
    public float distance;
    public Transform groundcheck;

    private Animator anim;
    private Rigidbody2D body;

    private new void Start () {
        base.Start ();

        anim = GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D> ();
    }

    private void Update () {
        if (Input.GetMouseButtonDown (0)) {
            body.AddForce (new Vector2 (strong, strong), ForceMode2D.Impulse);
        }

        var ground = (!Physics2D.Raycast (groundcheck.position, Vector2.down, distance));

        Debug.DrawRay (groundcheck.position, Vector2.down * distance);

        anim.SetBool ("jump", ground);
        anim.SetFloat ("yPos", body.velocity.y);

        if (Input.GetMouseButtonDown (1))
            ApplyDamage (1);
    }

    protected override void OnDeath () {
        Destroy (gameObject);
    }
}