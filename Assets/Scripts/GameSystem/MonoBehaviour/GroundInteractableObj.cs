using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInteractableObj : InteractableObjMonoBase
{
    /// <summary>
    /// �Ӫ���i�_�Q����
    /// </summary>
    private bool canInteractive = false;
    public bool CanInteractive
    {
        get { return canInteractive; }
        set { canInteractive = value; }
    }
    public override void InteractiveEvent()
    {
        Debug.Log("���椬�ʪ���ƥ�");

    }
}
