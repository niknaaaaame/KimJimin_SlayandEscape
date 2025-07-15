using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpController : MonoBehaviour
{

    public Player player;
    public GameObject hpPrefab;
    public RectTransform hpParent;

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
            GameObject hp = Instantiate(hpPrefab, hpParent);
            RectTransform rt = hp.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(50f + (i * 100f), 50f);
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
            Image img = hpList[i].GetComponent<Image>();
            if (img != null)
            {
                img.color = (i < player.hp) ? Color.white : Color.black;
            }
        }
    }
}
