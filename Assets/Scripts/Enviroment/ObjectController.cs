using UnityEngine;

public class ObjectController : MonoBehaviour {
    public Transform @object;
    public Transform A, B;
    public float speed;

    public bool lookRight;

    private Vector3 target;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = @object.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = lookRight;
        target = B.position;
    }


    private void Update() {
        @object.position = Vector3.MoveTowards(@object.position, target, speed * Time.deltaTime);

        if(@object.position == target) {
            target = (target == B.position) ? A.position : B.position;     

            lookRight = !lookRight;

            spriteRenderer.flipX = lookRight;
        }           
    }
}