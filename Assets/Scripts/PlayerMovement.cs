using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private List<KeyCode> keysPressed = new List<KeyCode>();
    private Rigidbody2D rb;
    private float horizontal;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello world! " + speed);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Don't hate me! " + speed);
        if(Input.GetKeyDown(KeyCode.D)) {
            //Debug.Log("D pressed");
           // keysPressed.Add(KeyCode.D);
        }
        if(Input.GetKeyUp(KeyCode.D)) {
            //keysPressed.Remove(KeyCode.D);
        }
        if (isFacingRight && horizontal < 0f) Flip();
        if (!isFacingRight && horizontal > 0f) Flip();
    }

    void FixedUpdate() {
        /*if (keysPressed.Contains(KeyCode.D)) {
            //transform.position = new Vector2(transform.position.x + (speed*Time.deltaTime),transform.position.y);
            rb.velocity = new Vector2(speed,rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }*/
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void OnJump(InputValue value) {
        Debug.Log("Jumping!");
        if (value.isPressed && IsGrounded())
            rb.velocity = new Vector2(rb.velocity.x,jumpPower);
        else if(rb.velocity.y > 0f) rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y * .5f);
    }

    void OnMove(InputValue value) {
        Debug.Log("Moving: " + value.Get<float>());
        horizontal = value.Get<float>();
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle( groundCheck.position, .1f, groundLayer);
    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
