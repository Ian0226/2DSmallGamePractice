using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    public static MainGameManager mainGameManager = null;
    void Awake()
    {
        mainGameManager = this;
        Initialize();
    }
    public void Initialize()
    {
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        
    }
    
    void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            //Debug.Log(enemies[i]);
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
        if (enemies.Count == 0)
        {
            GameStart.instance.GameWin();
        }
    }
}
