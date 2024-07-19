using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float bulletRotate;
    private bool bulletDirection;
    public bool BulletDirection
    {
        get { return bulletDirection; }
        set { bulletDirection = value; }
    }
    private void Awake()
    {
        Invoke("DestroyThis",1);
    }
    private void Update()
    {
        if (!bulletDirection)
        {
            this.gameObject.transform.position += new Vector3(0.5f, 0, 0);
        }
        else
        {
            this.gameObject.transform.position -= new Vector3(0.5f, 0, 0);
        }
        bulletRotate +=4.5f;
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -bulletRotate);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
