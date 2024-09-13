using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.CustomTool;
using System;
using DG.Tweening;

/// <summary>
/// �a�Ϥ��i���ʪ�����A���a���b����U�詹�W���I��������Y�iĲ�o���ʨƥ�A����Y�|�ͦ��S�w����X�ӡA�����Q�ڨ��ˡA
/// �����O�����޲z�Ҧ������W���i���ʪ���C
/// </summary>
public class InteractableGroundHandler : InteractableObjBase
{
    /// <summary>
    /// �������i���ʦa������
    /// </summary>
    private List<Transform> groundTransform = new List<Transform>();

    /// <summary>
    /// �������i���ʦa������Component
    /// </summary>
    private List<GroundInteractableObj> gdInteractObjComponents = new List<GroundInteractableObj>();

    /// <summary>
    /// �x�s�C���ͦ�������
    /// </summary>
    private GameObject currentInsObj;

    /// <summary>
    /// �P�Ӫ��󤬰ʮɭn�ͦ�������
    /// </summary>
    private GameObject instantiateObj;

    /// <summary>
    /// �ͦ����󪺦�m
    /// </summary>
    private Vector2 instantiatePos;

    /// <summary>
    /// ��e���ʨ쪺����
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
        Debug.Log("���椬�ʪ���ƥ�");
        instantiatePos = currentInteractiveObj.position;
        HandleIns(instantiateObj);
    }
    
    /// <summary>
    /// �B�z�ͦ�����
    /// </summary>
    /// <param name="insObj">�n�ͦ�������</param>
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
