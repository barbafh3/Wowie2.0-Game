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

        if (distance < 6) {
            barrel.rotation = Quaternion.Euler (0, 0, distance * 10);

        } else {
            barrel.rotation = Quaternion.Euler (0, 0, 60);

        }


        Debug.Log (distance);
    }

    public void Shoot () {
        var shootTemp = Instantiate (shoot, barrel.position, barrel.rotation);

        // var strong = (distance <= 3) ? distance * 1.4f : distance;
        var strong = 0f;
        if(distance <= 3)
            strong = distance * 1.5f;

        else if(distance > 7)
            strong = distance - 1;
        
        else if(distance > 9)
            strong = distance - 3f;
        
        else
            strong = distance;
            

        shootTemp.GetComponent<CannonShoot> ().Shooting (strong, barrel.up);
    }
}