using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    private int choice = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (choice == 1)
            {
                choice = 0;
            }
            else
            {
                choice++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (choice == 0)
            {
                choice = 1;
            }
            else
            {
                choice--;
            }
        }

        if (choice == 0)
        {
            transform.position = new Vector3(-7f, -1f, 0f);
        }
        if (choice == 1)
        {
            transform.position = new Vector3(1f, -1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (choice == 0)
            {
                SceneManager.LoadScene("Main");
            }
            else
            {
                Debug.Log("게임 종료됨!");
                Application.Quit();
            }
        }
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //Debug.Log("���� ����!");
        //Application.Quit();
        //}
    }
}
