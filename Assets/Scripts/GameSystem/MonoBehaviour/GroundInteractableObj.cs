using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地圖互動物件
/// </summary>
public class GroundInteractableObj : InteractableObjMonoBase
{
    /// <summary>
    /// 該物件可否被互動
    /// </summary>
    [SerializeField]
    private bool canInteractive = false;
    public bool CanInteractive
    {
        get { return canInteractive; }
        set { canInteractive = value; }
    }
}
