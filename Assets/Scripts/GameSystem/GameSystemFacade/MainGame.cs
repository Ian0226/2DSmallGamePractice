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

    //Class member
    private PlayerContol _playerControl = null;
    private InteractableGroundHandler _interactableObjHandler = null;

    public void Initialize()
    {
        Debug.Log("Game initial start");
        _playerControl = new PlayerContol(this);
        _interactableObjHandler = new InteractableGroundHandler(this);
    }
    
    public void Update()
    {
        _playerControl.Update();
        _interactableObjHandler.Update();
    }

    public void Release()
    {

    }

    #region methods



    #endregion
}
