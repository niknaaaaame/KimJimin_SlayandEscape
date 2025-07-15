using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpController : MonoBehaviour
{

    public Player player;
    public GameObject hpPrefab;

    public float xPos = 50f;
    public float yPos = 50f;

    private List<GameObject> hpList = new List<GameObject>();
    private int lastHp;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        for (int i = 0; i < player.hp; i++)
        {
            GameObject hp = Instantiate(hpPrefab, new Vector2(xPos + (i * 100f), yPos), transform.rotation);
            hpList.Add(hp);
        }

        lastHp = player.hp;


    }

    // Update is called once per frame
    void Update()
    {
        if (player.hp != lastHp)
        {
            UpdateHpDisplay();
            lastHp = player.hp;
        }
    }


    private void UpdateHpDisplay()
    {
        for (int i = 0; i < hpList.Count; i++)
        {
            if (i < player.hp)
            {
                SetHeartColor(hpList[i], Color.white);
            }
            else
            {
                SetHeartColor(hpList[i], Color.black);
            }
        }
    }

    private void SetHeartColor(GameObject heart, Color color)
    {
        SpriteRenderer sr = heart.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = color;
        }
    }
}
