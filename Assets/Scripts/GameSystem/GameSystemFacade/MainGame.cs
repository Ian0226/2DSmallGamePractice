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

    private PlayerContol playerControl = null;

    public void Initialize()
    {
        Debug.Log("Game initial start");
        playerControl = new PlayerContol(this);
    }
    
    public void Update()
    {
        playerControl.Update();
    }

    public void Release()
    {
        
    }

    #region methods



    #endregion
}
