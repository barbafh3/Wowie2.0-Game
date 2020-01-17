using UnityEngine;

public class Cannon : MonoBehaviour {

    public Transform barrel;
    public GameObject shoot;

    private float distance;
    private Transform target;

    private void Start () {
        target = GameObject.FindWithTag ("Player").transform;
    }

    private void Update () {
        distance = Vector2.Distance (transform.position, target.position);

        barrel.rotation = Quaternion.Euler (0, 0, distance * 10);
    }

    public void Shoot () {
        var shootTemp = Instantiate (shoot, barrel.position, barrel.rotation);

        var strong = (distance <= 3) ? distance * 1.4f : distance;

        shootTemp.GetComponent<CannonShoot> ().Shooting (strong, barrel.up);
    }
}