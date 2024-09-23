using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.CustomUITool;

public class InteractiveHintUI : UserInterface
{
    /// <summary>
    /// ���ʴ���UI
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
    /// �]�w����UI���X�{��m
    /// </summary>
    /// <param name="obj">�n�Q���ܪ�����</param>
    public void SetHintUIPos(GameObject obj)
    {
        rootUI.SetActive(true);
        //����Q���ܪ��󪺹Ϥ��b����������ڤj�p
        float objWidth = obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float objHeight = obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        
        float xOffset = 0.5f;
        float yOffset = 0.5f;

        hintImage.transform.position = new Vector2(obj.transform.position.x + objWidth / 2 + xOffset, obj.transform.position.y + objHeight / 2 + yOffset);
    }
}
