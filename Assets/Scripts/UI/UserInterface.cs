using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UserInterface
{
    protected MainGame mainGame = null;
    protected GameObject rootUI = null;

    protected bool active = true;
    public UserInterface(MainGame main)
    {
        mainGame = main;
    }

    public bool IsVisble() 
    {
        return active;
    }

    public virtual void Show() 
    {
        rootUI.SetActive(true);
        active = true;
    }
    public virtual void Hide() 
    {
        rootUI.SetActive(false);
        active = false;
    }

    public virtual void Initialize() { }
    public virtual void Update() { }
    public virtual void Release() { }
}
