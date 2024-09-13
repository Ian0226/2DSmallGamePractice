using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.CustomTool;
using System;
using DG.Tweening;

/// <summary>
/// 地圖中可互動的方塊，玩家站在方塊下方往上跳碰撞此方塊即可觸發互動事件，方塊即會生成特定物件出來，像瑪利歐那樣，
/// 此類別集中管理所有場景上的可互動物件。
/// </summary>
public class InteractableGroundHandler : InteractableObjBase
{
    /// <summary>
    /// 場景中可互動地面物件
    /// </summary>
    private List<Transform> groundTransform = new List<Transform>();

    /// <summary>
    /// 場景中可互動地面物件的Component
    /// </summary>
    private List<GroundInteractableObj> gdInteractObjComponents = new List<GroundInteractableObj>();

    /// <summary>
    /// 儲存每次生成的物件
    /// </summary>
    private GameObject currentInsObj;

    /// <summary>
    /// 與該物件互動時要生成的物件
    /// </summary>
    private GameObject instantiateObj;

    /// <summary>
    /// 生成物件的位置
    /// </summary>
    private Vector2 instantiatePos;

    /// <summary>
    /// 當前互動到的物件
    /// </summary>
    private Transform currentInteractiveObj;

    public InteractableGroundHandler(MainGame main) : base(main)
    {
        Initialize();
    }

    public override void Initialize()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("InteractableGround"))
        {
            groundTransform.Add(obj.transform);
        }
        groundTransform.Sort((a, b) => { return a.name.CompareTo(b.name); });

        //Set GroundInteractableObj component to obj
        foreach (Transform obj in groundTransform)
        {
            gdInteractObjComponents.Add(SetObjComponent(obj.gameObject));
            Debug.Log(obj.name);//Test
        }

        InitParam();
    }

    private void InitParam()
    {
        instantiateObj = (GameObject)Resources.Load("Prefabs/TestDoor");
        Debug.Log(instantiateObj);
    }

    /// <summary>
    /// Set ground interactable object component and do initialize
    /// </summary>
    /// <param name="obj">GroundInteractable object</param>
    private GroundInteractableObj SetObjComponent(GameObject obj)
    {
        GroundInteractableObj gdObj = obj.AddComponent<GroundInteractableObj>();
        //gdInteractObjComponents.Add(gdObj);
        //Init GroundInteractable object param
        gdObj.CanInteractive = true;
        gdObj.InteractiveEvent = ObjInteractiveEvent;
        return gdObj;
    }

    /// <summary>
    /// Get ground interactable object component by index
    /// </summary>
    /// <param name="index">Index have to minus 1</param>
    /// <returns></returns>
    public GroundInteractableObj GetGroundInteractableObjIndex(int index)
    {
        currentInteractiveObj = gdInteractObjComponents[index].gameObject.transform;
        return gdInteractObjComponents[index];
    }

    public override void ObjInteractiveEvent()
    {
        Debug.Log("執行互動物件事件");
        instantiatePos = currentInteractiveObj.position;
        HandleIns(instantiateObj);
    }
    
    /// <summary>
    /// 處理生成物件
    /// </summary>
    /// <param name="insObj">要生成的物件</param>
    private void HandleIns(GameObject insObj)
    {
        currentInsObj = MonoBehaviour.Instantiate(insObj,instantiatePos,Quaternion.identity);
        //Animation
        float endPosY = 1.12f;
        float duration = 0.5f;
        currentInsObj.transform.DOMoveY(instantiatePos.y + endPosY, duration).
            OnComplete(() => { Debug.Log("End Animation"); });
    }
}
