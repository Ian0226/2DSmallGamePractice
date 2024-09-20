using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.CustomTool;
using Unity.CustomUITool;

public class SubtitleUI : UserInterface
{
    private GameObject textContainerUI = null;
    private Text textComponent;
    public SubtitleUI(MainGame main) : base(main)
    {
        Initialize();
    }

    public override void Initialize()
    {
        textContainerUI = UnityTool.FindGameObject("DefaultDialogPrefab(Clone)");
        textContainerUI.GetComponent<Canvas>().worldCamera = Camera.main;
        //textContainerUI.transform.position = mainGame.GetPlayerControl().PlayerTransform.position;
        //textContainerUI.SetActive(false);
        textComponent = UITool.GetUIComponent<Text>(textContainerUI, "DialogText");
        //Debug.Log(textComponent.text);
        //textComponent.text += "OK";
    }

    public override void Update()
    {
        textContainerUI.transform.position = mainGame.GetPlayerControl().PlayerTransform.position;
    }

}
