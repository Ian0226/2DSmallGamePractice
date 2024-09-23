using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.CustomTool;
using Unity.CustomUITool;

public class SubtitleUI : UserInterface
{
    //private GameObject textContainerUI = null;
    private Text textComponent;
    public SubtitleUI(MainGame main) : base(main)
    {
        Initialize();
    }

    public override void Initialize()
    {
        rootUI = UnityTool.FindGameObject("DefaultDialogPrefab(Clone)");
        //textContainerUI = UnityTool.FindGameObject("DefaultDialogPrefab(Clone)");
        rootUI.GetComponent<Canvas>().worldCamera = Camera.main;
        //textContainerUI.transform.position = mainGame.GetPlayerControl().PlayerTransform.position;
        //textContainerUI.SetActive(false);
        textComponent = UITool.GetUIComponent<Text>(rootUI, "DialogText");
        
        rootUI.SetActive(false);
    }

    public override void Update()
    {
        rootUI.transform.position = mainGame.GetPlayerControl().PlayerTransform.position;
    }
}
