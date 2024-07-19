using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject gameOverTitle;
    public GameObject gameWinTitle;
    public GameObject bg;
    public Button returnBtn;
    public Button exitBtn;

    public static GameStart gameStartInstance;

    public static GameStart instance = null;
    private void Start()
    {
        instance = this;
        //gameOverTitle.SetActive(false);
    }
    private void Update()
    {
        
    }
    public void GameOver()
    {
        gameOverTitle.transform.parent.gameObject.SetActive(true);
        gameOverTitle.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameWin()
    {
        gameWinTitle.transform.parent.gameObject.SetActive(true);
        gameWinTitle.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
