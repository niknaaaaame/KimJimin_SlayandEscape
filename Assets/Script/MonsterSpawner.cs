using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Player player;

    //public int monsterMax = 100;
    public float timeBetMin = 3f;
    public float timeBetMax = 5f;
    private float timeBetSpawn;
    private float lastSpawnTime;

    public float xMin = -16f;
    public float xMax = 35f;
    private float yPos = 5f;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= lastSpawnTime + timeBetSpawn && !player.isDead)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetMin, timeBetMax);

            float xPos = Random.Range(xMin, xMax);

            GameObject monster = Instantiate(monsterPrefab, new Vector2(xPos, yPos), transform.rotation);

        }
    }
}
