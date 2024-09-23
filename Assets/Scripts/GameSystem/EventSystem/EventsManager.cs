using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contain game events
/// </summary>
public class EventsManager : GameSystemBase
{
    private List<EventObject> eventObjects = new List<EventObject>();

    public EventsManager(MainGame main) : base(main)
    {
        Initialize();
    }

    public override void Initialize()
    {
        //��l��eventObjects
        List<GameObject> objs = new List<GameObject>(GameObject.FindGameObjectsWithTag("EventObject"));
        objs.ForEach((element) => { eventObjects.Add(element.GetComponent<EventObject>());});
        
        //�]�weventsObjects��eventAction

    }
}
