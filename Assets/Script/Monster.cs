using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 5f;
    public GameObject player;
    private Rigidbody2D monsterRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        monsterRigidbody.velocity = new Vector2(direction.x * speed, monsterRigidbody.velocity.y);


        // ��������Ʈ ���� (����)
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
            
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
