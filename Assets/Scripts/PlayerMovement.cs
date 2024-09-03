using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private List<KeyCode> keysPressed = new List<KeyCode>();
    Rigidbody2D rb;
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
    }

    void FixedUpdate() {
        /*if (keysPressed.Contains(KeyCode.D)) {
            //transform.position = new Vector2(transform.position.x + (speed*Time.deltaTime),transform.position.y);
            rb.velocity = new Vector2(speed,rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }*/
    }

    void OnJump() {
        Debug.Log("Jumping!");
    }
}
