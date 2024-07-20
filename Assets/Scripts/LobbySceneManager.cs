using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
