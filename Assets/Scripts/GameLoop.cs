using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private MainGame _mainGame = null;

    private void Awake()
    {
        _mainGame = MainGame.Instance;
        _mainGame.Initialize();
    }

    private void Update()
    {
        _mainGame.Update();
    }
}
