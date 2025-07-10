using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 500f;
    public bool isAttacking = false;
    public bool isDead = false;

    private float attackTime = 0f;
    private bool isGrounded = false;
    private bool isRuning = false;

    //public int Hunt = 0;




    private Rigidbody2D playerRigidbody;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(isAttacking != true)
            {
                isDead = true;
                Die();
            }
            //else
            //{
            //    Hunt++;
            //    Debug.Log("적 처치!");
            //}
            
        }
       
        if(collision.gameObject.CompareTag("Ground"))
        {
            
            isGrounded = true;
            

        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            isDead = true;
            Die();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Ground"))
        {
            
            isGrounded = false;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        animator.SetBool("Jump", !isGrounded);
        animator.SetBool("Run", isRuning);
        
        float moveInput = 0f;
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
            transform.localScale = new Vector3(1, 1, 1);
            isRuning = true;   
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
            transform.localScale = new Vector3(-1, 1, 1);
            isRuning = true; 
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRuning = false; 
        }

        if(Input.GetKeyDown(KeyCode.Z) && isAttacking==false && isGrounded)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
        }

        if(isAttacking == true)
        {
            //Debug.Log("공격 중!");
            attackTime += Time.deltaTime;
        }

        

        if(attackTime >= 0.5f)
        {
            isAttacking = false;
            attackTime = 0f;
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
        animator.SetTrigger("Death");
        //gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
        Destroy(gameObject, 1f);
    }
}
