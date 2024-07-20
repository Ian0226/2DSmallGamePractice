using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame
{
    private static MainGame _instance;
    public static MainGame Instance
    {
        get { if (_instance == null) _instance = new MainGame();
            return _instance;
        }
    } 
    private MainGame()
    {
        Initialize();
    }

    public void Initialize()
    {
        Debug.Log("Game initial start");
    }
    
    public void Update()
    {

    }

    public void Release()
    {

    }
}
