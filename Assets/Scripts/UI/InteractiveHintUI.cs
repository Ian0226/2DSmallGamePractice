using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.CustomUITool;

public class InteractiveHintUI : UserInterface
{
    /// <summary>
    /// 互動提示UI
    /// </summary>
    private GameObject hintImage;
    public InteractiveHintUI(MainGame main) : base(main)
    {
        Initialize();
    }

    public override void Initialize()
    {
        rootUI = GameObject.Find("HintCanvas");
        rootUI.SetActive(false);

        hintImage = rootUI.transform.GetChild(0).gameObject;
    }

    /// <summary>
    /// 設定提示UI的出現位置
    /// </summary>
    /// <param name="obj">要被提示的物件</param>
    public void SetHintUIPos(GameObject obj)
    {
        rootUI.SetActive(true);
        //獲取被提示物件的圖片在場景中的實際大小
        float objWidth = obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float objHeight = obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        
        float xOffset = 0.5f;
        float yOffset = 0.5f;

        hintImage.transform.position = new Vector2(obj.transform.position.x + objWidth / 2 + xOffset, obj.transform.position.y + objHeight / 2 + yOffset);
    }
}
