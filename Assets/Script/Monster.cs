using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 5f;
    public Player player;
    public float jumpForce = 5f;
    private Rigidbody2D monsterRigidbody;
    private Animator animator;
    public Vector2 offset = new Vector3(0, 1f);

    public float hp = 5f;
    private float invincibilityTime = 1f;
    private float LastHitTime;

    private bool isWalking = false;
    public bool isDead = false;
    private bool isGrounded = false;
    private bool isJumping = false;

    public GameObject BulletPrefab;

    public float timeBetMin = 5f;
    public float timeBetMax = 10f;
    private float timeBetSpawn;
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        lastSpawnTime = Time.time;
        timeBetSpawn = Random.Range(timeBetMin, timeBetMax);
        LastHitTime = Time.time;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (isGrounded)
            {
                isJumping = true;
                monsterRigidbody.velocity = new Vector2(monsterRigidbody.velocity.x, 0f);
                monsterRigidbody.velocity = new Vector2(monsterRigidbody.velocity.x, jumpForce);
                isJumping = false;
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {

            isGrounded = true;


        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {

            isGrounded = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead || isJumping)
        {
            return;
        }
        animator.SetBool("Run", isWalking);
        if (player != null)
        {
            isWalking = true;
            Vector2 direction = (player.transform.position - transform.position).normalized;
            monsterRigidbody.velocity = new Vector2(direction.x * speed, monsterRigidbody.velocity.y);

            if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        isWalking = false;


        if (Time.time >= lastSpawnTime + timeBetSpawn && !player.isDead)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetMin, timeBetMax);

            GameObject bullet = Instantiate(BulletPrefab, new Vector2(transform.position.x, transform.position.y) + offset, transform.rotation);
            Debug.Log("총알 소환됨!");

        }




        // ��������Ʈ ���� (����)


    }

    public void Die()
    {
        isDead = true;
        gameObject.tag = "DeadMonster";
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.3f);
    }

    public int Hit(int atk)
    {
        if (Time.time >= LastHitTime + invincibilityTime)
        {
            hp -= atk;
            Debug.Log("몬스터" + hp);
            LastHitTime = Time.time;
            if (hp <= 0)
            {
                Die();
                return 1;
            }
        }
        return 0;
        
    }
    
}
