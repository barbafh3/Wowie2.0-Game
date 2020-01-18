using UnityEngine;
using System.Collections;

public class Wizard : EnemyBase {

    public float countdown = 3;

    private Cannon cannon => FindObjectOfType<Cannon> ();
    private Animator anim => GetComponent<Animator> ();

    private float timer;



    private void Update() {
        timer += Time.deltaTime;

        if(timer >= countdown) {
            timer = 0;
            StartCoroutine("Attack");
        }
    }


    public IEnumerator Attack() {
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(1.5f);
        cannon.Shoot();
    }

    protected override void OnDeath () {
        anim.SetTrigger ("death");
    }

}