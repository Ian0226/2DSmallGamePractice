using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameLoop : MonoBehaviour
{
    private MainGame mainGame = null;
    private void Awake()
    {
        mainGame = MainGame.Instance;
        mainGame.Initialize();
    }

    private void Update()
    {
        mainGame.Update();
    }
}
