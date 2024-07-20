using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveGround : MonoBehaviour
{
    [SerializeField]
    private Collider2D colliderObj;

    private Collider2D thisCollider;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject door;
    private bool isTouch;

    private GameObject obj;

    private void Start()
    {
        thisCollider = this.GetComponent<BoxCollider2D>();
        isTouch = true;
    }
    void Update()
    {
        if (colliderObj.IsTouchingLayers(256))
        {
            if (this.thisCollider.IsTouchingLayers(256))
            {
                if(isTouch)
                {
                    obj = Instantiate(door, new Vector2(this.transform.position.x,this.transform.position.y+1.2f),Quaternion.identity);
                    obj.transform.localScale = new Vector2(obj.transform.localScale.x - 3.5f, obj.transform.localScale.y - 3.5f);
                    obj.AddComponent<Rigidbody2D>();
                    obj.GetComponent<BoxCollider2D>().isTrigger = false;
                    obj.tag = "InteractiveObj";
                    isTouch = false;
                }
                    
            }
        }
        if(obj!=null)
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(300 * Time.deltaTime, obj.GetComponent<Rigidbody2D>().velocity.y);
    }
    
}
