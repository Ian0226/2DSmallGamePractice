using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContol : MonoBehaviour
{
    public float speed;

    public Animator Player;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public float jumpForce;

    //public GameObject groundObject;

    public float originTransform_y;

    public BoxCollider2D coll;

    public LayerMask ground;

    public bool isGround = false;

    private Camera camera_2;

    [SerializeField]
    private GameObject bullet;


    void Start()
    {
        originTransform_y = this.transform.position.y;
        camera_2 = GameObject.Find("Main Camera").GetComponent<Camera>();
        Time.timeScale = 1;
        
    }

    void Update()
    {
        camera_2.transform.position = this.gameObject.transform.GetChild(0).position;
        if(coll.IsTouchingLayers(ground))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        /*float horizontalMove;
        horizontalMove = Input.GetAxis("Horizontal");
        if(horizontalMove!=0)
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        */
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player.SetFloat("speed", 1);
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            sr.flipX = true;
            
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            Player.SetFloat("speed", 1);
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            sr.flipX = false;
            
        }
        else
        {
            Player.SetFloat("speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Debug.Log(isGround);
            rb.AddForce(Vector2.up * jumpForce);
            Player.SetTrigger("jump");
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Player.SetTrigger("attack");
            Shoot();
        }
        Player.SetBool("isGround", isGround);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "InteractiveObj")
        {
            GameObject obj = GameObject.Find("Door_1");
            //obj.transform.localScale = new Vector2(obj.transform.localScale.x + 3, obj.transform.localScale.y + 3);
            obj.transform.position = new Vector2(9.34f, -1.78f);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Ground_Dead")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameStart.instance.GameOver();
            Destroy(this.gameObject);
        }

    }
    private void Shoot()
    {
        
        if (this.GetComponent<SpriteRenderer>().flipX)
        {
            GameObject nowBullet = Instantiate(bullet, new Vector2(this.transform.position.x - 1, this.transform.position.y - 0.1f), 
                Quaternion.identity);
            nowBullet.GetComponent<BulletController>().BulletDirection = true;
        }
        else
        {
            GameObject nowBullet = Instantiate(bullet, new Vector2(this.transform.position.x + 1, this.transform.position.y + 0.1f),
            Quaternion.identity);
        }
        
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundObject = collision.gameObject;
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == groundObject)
        {
            groundObject = null;
            isGround = false;
        }
    }
    */
}
