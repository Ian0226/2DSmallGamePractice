using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.UI;

/// <summary>
/// Control subtitleUI
/// </summary>
public class SubtitleSystem : GameSystemBase
{
    private FlowerSystem _flowerSys = null;

    public SubtitleSystem(MainGame main) : base(main)
    {
        Initialize();
    }

    public override void Initialize()
    {
        _flowerSys = FlowerManager.Instance.CreateFlowerSystem("FlowerSystem", false);
        _flowerSys.ReadTextFromResource("TXTs/TestText");
        _flowerSys.SetupDialog();
    }
}
