using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoor : MonoBehaviour
{
    private GameObject current;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(current)
                this.transform.position = current.GetComponent<Door>().GetDestination().position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Door"))
        {
            current = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            if(collision.gameObject == current)
                current = null;
        }
    }

    //For test
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
    }
}
