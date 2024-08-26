using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.CustomTool;
using System;

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
    /// 玩家物件
    /// </summary>
    private Transform playerTrans;

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
    /// 互動時要執行的事件
    /// </summary>
    public Action interactiveEvent { get { return objEvent; } }

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
    }

    /// <summary>
    /// Set ground interactable object component
    /// </summary>
    /// <param name="obj">GroundInteractable object</param>
    private GroundInteractableObj SetObjComponent(GameObject obj)
    {
        GroundInteractableObj gdObj = obj.AddComponent<GroundInteractableObj>();
        gdInteractObjComponents.Add(gdObj);
        //Init GroundInteractable object param
        gdObj.CanInteractive = true;
        return gdObj;
    }

    /// <summary>
    /// Get ground interactable object component by index
    /// </summary>
    /// <param name="index">Index have to minus 1</param>
    /// <returns></returns>
    public GroundInteractableObj GetGroundInteractableObjIndex(int index)
    {
        return gdInteractObjComponents[index];
    }

    public override void ObjInteractiveEvent()
    {
        HandleIns(instantiateObj);
    }
    
    /// <summary>
    /// 處理生成物件
    /// </summary>
    /// <param name="insObj">要生成的物件</param>
    private void HandleIns(GameObject insObj)
    {
        currentInsObj = MonoBehaviour.Instantiate(insObj,instantiatePos,Quaternion.identity);
    }
}
