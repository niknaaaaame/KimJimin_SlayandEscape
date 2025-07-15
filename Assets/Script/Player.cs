using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 500f;
    public bool isAttacking = false;
    public bool isDead = false;

    public int hp = 3;
    private float invincibilityTime = 1f;
    private float LastHitTime;

    private float attackTime = 0f;
    private bool isGrounded = false;
    private bool isRuning = false;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float fadeTimer = 0f;
    private float fadeDuration = 1f;
    private bool isFadingBack = false;

    //public int Hunt = 0;




    private Rigidbody2D playerRigidbody;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        LastHitTime = Time.time;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time >= LastHitTime + invincibilityTime)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (isAttacking != true)
                {
                    Hit(); 
                    //Debug.Log(hp);
                    //isDead = true;
                    //hp--;
                }
                //else
                //{
                //    Hunt++;
                //    Debug.Log("적 처치!");
                //}

            }

            if (collision.gameObject.CompareTag("Bullet"))
            {
                Hit();
            }
            LastHitTime = Time.time;
        }
        
            
        if (collision.gameObject.CompareTag("Ground"))
        {

            isGrounded = true;


        }
        
    }


    private void Hit()
    {
        //Debug.Log(hp);
        hp--;
        spriteRenderer.color = Color.red;
        fadeTimer = 0f;
        isFadingBack = true;
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //if (collision.tag == "Bullet")
    //{
    //Debug.Log(hp);
    //isDead = true;
    //Die();
    //hp--;
    //}

    //}

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

        if (isFadingBack)
        {
            fadeTimer += Time.deltaTime;
            float timer = fadeTimer / fadeDuration;

            spriteRenderer.color = Color.Lerp(Color.red, originalColor, timer);

            if (timer >= 1f)
            {
                spriteRenderer.color = originalColor;
                isFadingBack = false;
            }
        }
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

        if (Input.GetKeyDown(KeyCode.Z) && isAttacking == false && isGrounded)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
        }

        if (isAttacking == true)
        {
            //Debug.Log("공격 중!");
            attackTime += Time.deltaTime;
        }



        if (attackTime >= 0.5f)
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

        if (hp <= 0)
        {
            hp = 0;
            isDead = true;
            Die();
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
