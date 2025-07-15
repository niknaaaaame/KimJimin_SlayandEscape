using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHp : MonoBehaviour
{
    public Transform monsterPosition;           
    public Transform hpBarBackground; 
    public Transform hpBarFill;

    public Monster monster;
    private float maxHp;
    private float currentHp;

    //public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

        monster = FindObjectOfType<Monster>();
        maxHp = monster.hp;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = monsterPosition.position + offset;
        currentHp = monster.hp;

        float hpRatio = (currentHp / maxHp) * 1.5f;
        if (hpRatio <= 0)
        {
            hpRatio = 0;
        }
        hpBarFill.localScale = new Vector3(hpRatio, 0.1f, 1f);

    }

    //public void SetHp(float hp)
    //{
        //currentHp = Mathf.Clamp(hp, 0, maxHp);
    //}
}
