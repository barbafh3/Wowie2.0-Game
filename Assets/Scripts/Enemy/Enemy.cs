using System.Collections;
using UnityEngine;

public class Enemy : EnemyBase {

    private void Update () {
        if (Input.GetMouseButtonDown (0))
            ApplyDamage (1);
    }

    protected override void OnDeath () {
        Destroy (transform.parent.gameObject);
    }
}