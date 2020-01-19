using UnityEngine;

public class Frog : EnemyBase {

    public float strong;
    public float distance;
    public AudioClip idle;
    public AudioClip jump;
    public Transform groundcheck;

    private Animator anim;
    private Rigidbody2D body;

    private new void Start () {
        base.Start ();

        anim = GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D> ();
        source = GetComponent<AudioSource> ();
    }

    private void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Jump ();
        }

        var ground = (!Physics2D.Raycast (groundcheck.position, Vector2.down, distance));

        anim.SetBool ("jump", ground);
        anim.SetFloat ("yPos", body.velocity.y);

        if (Input.GetMouseButtonDown (1))
            ApplyDamage (1);
    }

    protected override void OnDeath () {
        Sound("DEATH");
        spriteRenderer.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy (gameObject, 0.5f);
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Player")) {
            other.GetComponent<PlayerHealth> ().RemoveHealth (1);
        }
    }

    private void Jump () {
        body.AddForce (new Vector2 (strong, strong), ForceMode2D.Impulse);
        Sound("JUMP");
    }

    public void Sound (string sound) {
        switch (sound) {
            case "IDLE":
                source.PlayOneShot (idle);
                break;

            case "DEATH":
                source.PlayOneShot (dead, 3);
                break;

            case "JUMP":
                source.PlayOneShot (jump);
                break;
        }
    }

    protected override void OnHit () {
        Sound("DEATH");
    }

    private void OnBecameVisible() {
        anim.Play("idle");
    }
}