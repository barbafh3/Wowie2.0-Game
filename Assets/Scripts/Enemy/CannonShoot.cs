using UnityEngine;

public class CannonShoot : MonoBehaviour {

    public float strong;

    private Rigidbody2D body;

    private void Awake () {
        body = GetComponent<Rigidbody2D> ();
    }

    public void Shooting (float strong, Vector2 direction) {
        body.AddForce (direction * strong * 1.4f, ForceMode2D.Impulse);
    }
}