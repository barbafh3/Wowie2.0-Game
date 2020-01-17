using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  public float speed;

  public Rigidbody2D rb;

  public Animator animator;

  public float jumpHeight;

  bool _isJumping = false;


  void Update()
  {
    var horizontal = Input.GetAxisRaw("Horizontal");

    Move(horizontal);

    if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
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
    _isJumping = true;
    animator.SetBool("isFalling", false);
    rb.AddForce(Vector2.up * jumpHeight);
  }
}
