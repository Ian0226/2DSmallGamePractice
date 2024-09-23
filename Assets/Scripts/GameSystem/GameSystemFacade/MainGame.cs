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
    private SubtitleSystem _subtitleSystem = null;
    private EventsManager _eventsManager = null;

    //UI
    private SubtitleUI _subtitleUI = null;
    private InteractiveHintUI _interactiveHintUI = null;

    public void Initialize()
    {
        Debug.Log("Game initial start");
        _playerControl = new PlayerContol(this);
        _interactableObjHandler = new InteractableGroundHandler(this);
        _subtitleSystem = new SubtitleSystem(this);
        _eventsManager = new EventsManager(this);

        //UI
        _subtitleUI = new SubtitleUI(this);
        _interactiveHintUI = new InteractiveHintUI(this);

    }
    
    public void Update()
    {
        _playerControl.Update();
        _interactableObjHandler.Update();

        _subtitleUI.Update();
    }

    public void Release()
    {

    }

    #region methods
    /// <summary>
    /// Get PlayerControl object by this method, don't create new.
    /// </summary>
    /// <returns></returns>
    public PlayerContol GetPlayerControl()
    {
        if(_playerControl == null)
        {
            Debug.Log("PlayerControl物件尚未建立");
            return null;
        }
        else
        {
            return _playerControl;
        }
    }

    /// <summary>
    /// Get ground interactable object component by index
    /// </summary>
    /// <param name="index">Index have to minus 1</param>
    /// <returns></returns>
    public GroundInteractableObj GetGroundInteractableObjIndex(int index)
    {
        return _interactableObjHandler.GetGroundInteractableObjIndex(index);
    }

    /// <summary>
    /// Show subtile ui
    /// </summary>
    public void ShowSubtileUI()
    {
        _subtitleUI.Show();
    }

    /// <summary>
    /// Hide subtitle ui
    /// </summary>
    public void HideSubtileUI()
    {
        _subtitleUI.Hide();
    }

    public void SetHintUIPos(GameObject obj)
    {
        if(_interactiveHintUI!=null)
            _interactiveHintUI.SetHintUIPos(obj);
    }


    #endregion
}
