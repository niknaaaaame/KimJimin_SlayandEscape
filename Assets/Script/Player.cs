using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 500f;

    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    // Update is called once per frame
    void Update()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
        }

        Vector2 velocity = playerRigidbody.velocity;
        velocity.x = moveInput * speed;
        playerRigidbody.velocity = velocity;


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.AddForce(new Vector2(0, jumpForce));
            }
            
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
