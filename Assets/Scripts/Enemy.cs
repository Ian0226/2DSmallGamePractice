using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health;

    private GameObject hpBar;

    private GameObject[] hpSpriteObj;

    private int hpCount;

    private void Awake()
    {
        hpBar = this.transform.GetChild(0).transform.GetChild(0).gameObject;
        hpSpriteObj = new GameObject[hpBar.transform.childCount];
        hpCount = hpBar.transform.childCount;
        for (int i = 0; i < hpBar.transform.childCount; i++)
        {
            hpSpriteObj[i] = hpBar.transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        hpBar.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 5);
        if (health == 0)
        {
            Destroy(hpBar);
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        for(int i = 0; i < hpCount; i++)
        {
            hpSpriteObj[hpCount-1].SetActive(false);
        }
        hpCount -= damage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
