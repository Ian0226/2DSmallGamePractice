using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 所有場景中可互動物件之父類別
/// </summary>
public abstract class InteractableObjBase : GameSystemBase
{
    public InteractableObjBase(MainGame main) : base(main)
    {

    }
    
    protected Transform objTransform;

    /// <summary>
    /// 物件被互動時要執行的方法
    /// </summary>
    public abstract void ObjInteractiveEvent();
}
