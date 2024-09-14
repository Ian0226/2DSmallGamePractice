using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private Stack<Collision2D> currentCollObjs = new Stack<Collision2D>();
    private PlayerContol player = null;

    private void Start()
    {
        player = MainGame.Instance.GetPlayerControl();
    }
    public Collision2D GetCurrentCollObj()
    {
        if (currentCollObjs.Count > 0)
        {
            //Debug.Log(currentCollObjs.Peek().gameObject.name);
            return currentCollObjs.Peek();
        }
        else return null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentCollObjs.Push(collision);
        Debug.Log(collision.gameObject.name);
        HandleCollisionObjByTag(collision,true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        currentCollObjs.Pop();
        HandleCollisionObjByTag(collision, false);
    }

    /// <summary>
    /// Handle collision
    /// </summary>
    /// <param name="collision">The obj that collisioned</param>
    /// <param name="isEnter">Collision enter or collision exit</param>
    private void HandleCollisionObjByTag(Collision2D collision,bool isEnter)
    {
        if (isEnter)
        {
            //On collision enter
            switch (collision.transform.tag)
            {
                case "Ground":
                    player.SetPlayerIsGroundState(true);
                    break;
                case "InteractableGround":
                    Debug.Log(collision.gameObject.name);
                    if (player.RayHitGroundInteractiveObj)
                    {
                        player.InteractiveGroundFunc();
                    }
                    break;
            }
        }
        else 
        {
            //On collision exit
            switch (collision.transform.tag)
            {
                case "Ground":
                    player.SetPlayerIsGroundState(false);
                    break;
                case "InteractableGround":
                    Debug.Log(collision.gameObject.name);
                    break;
            }
        }
        
    }
}
