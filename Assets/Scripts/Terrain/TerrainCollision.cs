using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCollision : MonoBehaviour
{

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Shot"))
      other.gameObject.GetComponent<ShotMovement>().Collided();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Player"))
      other.gameObject.GetComponent<PlayerMovement>().Grounded();
  }
}
