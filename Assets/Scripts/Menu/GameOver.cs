using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public bool gameOver = false;

    void Start()
    {

    }

    void Update()
    {

       if(FindObjectOfType<Player>().currentHealth <= 0)
       {
            gameOver = true;
            gameOverUI.SetActive(true);            
            Time.timeScale = 0;
            return;
       }
       else if (FindObjectOfType<PauseMenu>().GameIsPaused == true)
       {
            Time.timeScale = 0;
            gameOver = false;
       }
       else
       {            
            Time.timeScale = 1;
            gameOver = false;
       }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayScene");
        gameOver = false;

    }
}
