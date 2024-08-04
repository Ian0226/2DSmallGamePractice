using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.CustomTool;
using System;

/// <summary>
/// �a�Ϥ��i���ʪ�����A���a���b����U�詹�W���I��������Y�iĲ�o���ʨƥ�A����Y�|�ͦ��S�w����X�ӡA�����Q�ڨ��ˡC
/// </summary>
public class InteractableGroundHandler : InteractableObjBase
{
    /// <summary>
    /// �������i���ʦa������
    /// </summary>
    private List<Transform> groundTransform = new List<Transform>();

    /// <summary>
    /// ���a����
    /// </summary>
    private Transform playerTrans;

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
    /// ���ʮɭn���檺�ƥ�
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
        
        foreach (Transform obj in groundTransform)//Test
        {
            Debug.Log(obj.name);
        }
    }

    public override void ObjInteractiveEvent()
    {
        HandleIns(instantiateObj);
    }

    /// <summary>
    /// �B�z�ͦ�����
    /// </summary>
    /// <param name="insObj">�n�ͦ�������</param>
    private void HandleIns(GameObject insObj)
    {
        currentInsObj = MonoBehaviour.Instantiate(insObj,instantiatePos,Quaternion.identity);
    }
}
