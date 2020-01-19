using System.Collections;
using UnityEngine;

public class Wizard : EnemyBase {


    private Cannon cannon => FindObjectOfType<Cannon> ();
    private Animator anim => GetComponent<Animator> ();

    private float timer;
    private float countdown = Mathf.Infinity;

    private void Update () {
        timer += Time.deltaTime;

        if (timer >= countdown) {
            timer = 0;
            StartCoroutine ("Attack");
        }
    }

    public IEnumerator Attack () {
        anim.SetTrigger ("attack");
        yield return new WaitForSeconds (0.3f);
        source.PlayOneShot(attack);
        yield return new WaitForSeconds (1.2f);
        cannon.Shoot ();
    }

    protected override void OnDeath () {
        anim.SetTrigger ("death");
        source.PlayOneShot(dead);
    }

    protected override void OnHit () {
        source.PlayOneShot(damage, 0.5f);
    }

    private void OnBecameVisible() {
        countdown = 3;
    }
}