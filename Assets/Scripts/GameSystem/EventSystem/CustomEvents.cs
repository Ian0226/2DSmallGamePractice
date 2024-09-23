using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 場景中要觸發的事件
/// </summary>
public class CustomEvents : GameSystemBase
{
    public CustomEvents(MainGame main) : base(main)
    {
        Initialize();
    }

    public override void Initialize()
    {
        
    }

    //所有遊戲中要觸發的事件皆於此
    #region Events
    private void PlayerSpeak(string sentence)
    {

    }

    #endregion
}
