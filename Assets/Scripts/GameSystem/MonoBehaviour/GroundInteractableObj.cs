using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInteractableObj : InteractableObjMonoBase
{
    /// <summary>
    /// 該物件可否被互動
    /// </summary>
    private bool canInteractive = false;
    public bool CanInteractive
    {
        get { return canInteractive; }
        set { canInteractive = value; }
    }
    public override void InteractiveEvent()
    {
        Debug.Log("執行互動物件事件");

    }
}
