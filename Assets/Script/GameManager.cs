using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int HuntProgress;
    private bool isGameOver;

    public int HuntGoal = 10;
    public Attack attack;

    public GameObject gameOverText;
    public Text ProgressText;
    // Start is called before the first frame update
    void Start()
    {
        
        HuntProgress = 0;
        isGameOver = false;
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HuntProgress = attack.hunt;
        if (!isGameOver)
        {
            ProgressText.text = "Hunt Progress: " + HuntProgress + " / " + HuntGoal;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
}
