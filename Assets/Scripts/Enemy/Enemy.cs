using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 2;
    public float health;

    private bool lookLeft;
    private bool death;
    private SpriteRenderer sprite;

    private void Start () {
        sprite = GetComponent<SpriteRenderer> ();
    }
   
    private void Update () {
        if (Input.GetMouseButtonDown (0))
            ApplyDamage (1);
    }

    public void ApplyDamage (float damage) {

        if (!death) {
            health -= damage;
            StartCoroutine (TakeDamage ());

            if (health <= 0 && !death) {
                death = true;
                Destroy(transform.parent.gameObject);
                // ANIMAÇÃO DE MORTE
            }
        }
    }

    private IEnumerator TakeDamage () {
        sprite.color = Color.red;
        yield return new WaitForSeconds (0.1f);
        sprite.color = Color.white;
    }
}