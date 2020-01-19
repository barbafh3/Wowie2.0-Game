using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollision : MonoBehaviour
{

  public PlayerMovement movement;

  void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("collided");
    if (other.CompareTag("Ground"))
    {
      movement.Grounded();
    }
  }
}
