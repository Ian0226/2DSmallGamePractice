using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InteractableObjMonoBase : MonoBehaviour
{
    protected Action interactiveEvent;
    public Action InteractiveEvent
    {
        get { return interactiveEvent; }
        set { interactiveEvent = value; }
    }
}
