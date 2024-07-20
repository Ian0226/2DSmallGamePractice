using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameSystemBase
{
    protected MainGame mainGame = null;
    public GameSystemBase(MainGame main)
    {
        mainGame = main;
    }

    public virtual void Initialize() { }
    public virtual void Update() { }
    public virtual void Release() { }
}
