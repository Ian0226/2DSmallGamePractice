using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �Ҧ��������i���ʪ��󤧤����O
/// </summary>
public abstract class InteractableObjBase : GameSystemBase
{
    public InteractableObjBase(MainGame main) : base(main)
    {

    }
    
    protected Transform objTransform;

    /// <summary>
    /// ����Q���ʮɭn���檺��k
    /// </summary>
    public abstract void ObjInteractiveEvent();
}
