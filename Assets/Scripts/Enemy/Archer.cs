using UnityEngine;
using System.Collections;

public class Archer : EnemyBase {

    public float countdown;
    public GameObject arrow;
    public Transform pointArrow;

    private Animator anim => GetComponent<Animator>();

    private float timer;


    private void Update() {
        timer += Time.deltaTime;
        if(timer >= countdown &&  !death) {
            timer = 0;
            anim.SetTrigger("attack");
            Invoke("SpawnArrow", 0.3f);
        }
    }


    private void SpawnArrow() {
        Instantiate(arrow, pointArrow.position, pointArrow.rotation);
    }


    protected override void OnDeath () {
        death = true;
        StartCoroutine("Death");
    }


    private IEnumerator Death() {
        GetComponent<CapsuleCollider2D>().enabled = false;
        anim.SetTrigger("death");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}