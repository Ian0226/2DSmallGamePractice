using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �a�Ϥ��ʪ���
/// </summary>
public class GroundInteractableObj : InteractableObjMonoBase
{
    /// <summary>
    /// �Ӫ���i�_�Q����
    /// </summary>
    [SerializeField]
    private bool canInteractive = false;
    public bool CanInteractive
    {
        get { return canInteractive; }
        set { canInteractive = value; }
    }
}
