using UnityEngine;
using System.Collections;

public abstract class EnemyBase : MonoBehaviour {

    public float speed = 2;
    public float health;

    protected bool lookLeft;
    protected bool death;
    protected SpriteRenderer spriteRenderer;
    protected Transform player;

    protected void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();  
        player = GameObject.FindWithTag("Player").transform;
    }


    public void ApplyDamage (float damage) {

        if (!death) {
            health -= damage;
            StartCoroutine (TakeDamage ());

            if (health <= 0 && !death) {
                death = true;
                OnDeath();
                // ANIMAÇÃO DE MORTE
            }
        }
    }

    protected IEnumerator TakeDamage () {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds (0.1f);
        spriteRenderer.color = Color.white;
    }

    protected abstract void OnDeath();
    
}