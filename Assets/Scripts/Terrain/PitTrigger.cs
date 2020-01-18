using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrigger : MonoBehaviour
{
  public Transform respawnTransform;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      other.GetComponent<PlayerMovement>().rb.velocity = Vector2.zero;
      other.transform.position = respawnTransform.position;
    }
  }
}
