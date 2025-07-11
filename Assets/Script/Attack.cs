using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Player player;
    public int hunt;
    public int atk = 3;
    //public Monster monster;
    // Start is called before the first frame update
    void Start()
    {
        hunt = 0;
        //player = GetComponent<Player>();
        //monster = GetComponent<Monster>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Monster monster = other.GetComponent<Monster>();
        if (other.CompareTag("Enemy") && player.isAttacking)
        {
            if (monster != null)
            {
                hunt += monster.Hit(atk);
                //hunt++;
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
