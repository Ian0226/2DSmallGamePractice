using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventObject : MonoBehaviour
{
    private Action eventAction;

    private void Awake()
    {
        
    }

    //Get set
    public Action GetEventAction()
    {
        return eventAction;
    }

    public void SetEventAction(Action action)
    {
        eventAction = action;
    }

    /// <summary>
    /// Trigger event action
    /// </summary>
    public void TriggerEvent()
    {
        eventAction.Invoke();
    }
}
