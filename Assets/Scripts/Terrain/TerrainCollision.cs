using UnityEngine;

public class TerrainCollision : MonoBehaviour
{

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Shot"))
      other.gameObject.GetComponent<ShotMovement>().Collided();
  }

  // void OnCollisionEnter2D (Collision2D other) {
  //   if (other.gameObject.CompareTag ("Player")) {
  //     other.gameObject.GetComponent<PlayerMovement> ().Grounded ();
  //     other.transform.SetParent(this.transform);
  //   }
  // }

  // private void OnCollisionExit2D(Collision2D other)
  // {
  //   if (other.gameObject.CompareTag("Player"))
  //     other.transform.SetParent(null);
  // }
}