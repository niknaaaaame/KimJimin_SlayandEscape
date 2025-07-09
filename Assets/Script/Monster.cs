using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 5f;
    public Player player;
    private Rigidbody2D monsterRigidbody;
    private Animator animator;

    private bool isWalking = false;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
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
        
        


        // ��������Ʈ ���� (����)
        
            
    }

    public void Die()
    {
        isDead = true;
        gameObject.tag = "DeadMonster";
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.5f);
    }
}
