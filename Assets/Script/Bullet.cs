using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;
    public float speed = 3f;

    private Rigidbody2D bulletRigidbody;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        direction = (player.transform.position - transform.position).normalized;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Enemy" && collision.tag != "Attack")
        {
            Destroy(gameObject);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
       
        transform.position += (Vector3)direction * speed * Time.deltaTime;
            
        
    }
}
