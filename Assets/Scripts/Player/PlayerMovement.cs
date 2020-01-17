using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  public float speed;

  public Rigidbody2D rb;

  public Animator animator;

  public float jumpHeight;

  public bool isJumping = false;


  void Update()
  {
    var horizontal = Input.GetAxisRaw("Horizontal");

    if (horizontal < 0)
    {
      transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
    }
    else if (horizontal > 0)
    {
      transform.localRotation = Quaternion.identity;
    }

    Move(horizontal);

    if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
    {
      Jump();
    }
  }

  void Move(float horizontal)
  {
    var movement = new Vector2(horizontal * speed, rb.velocity.y);
    rb.velocity = movement;
  }

  public void Jump()
  {
    rb.velocity = Vector2.zero;
    isJumping = true;
    rb.AddForce(Vector2.up * jumpHeight);
  }
}
