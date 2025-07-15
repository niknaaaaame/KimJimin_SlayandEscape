using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private AudioSource DoorAudio;
    public GameManager gameManager;
    private SpriteRenderer color;

    private bool DoorOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        DoorAudio = GetComponent<AudioSource>();
        color = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.HuntProgress >= gameManager.HuntGoal && !DoorOpen)
        {
            DoorAudio.Play();
            color.material.color = Color.black;
            DoorOpen = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (DoorOpen)
        {
            if (collision.tag == "Player")
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    SceneManager.LoadScene("Clear");
                }
                
            }
        }
        
    }
}
