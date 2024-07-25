using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.CustomTool;

public class PlayerContol : GameSystemBase
{
    /// <summary>
    /// The player's transform,only get this component here.
    /// </summary>
    private Transform _playerTransform;

    //Specific direction ray hit.
    private RaycastHit2D hitUpward;
    private RaycastHit2D hitLeft;
    private RaycastHit2D hitRight;

    private bool isJump = false;

    private float rayUpDistance;

    public float speed;

    public Animator playerAni;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public float jumpForce;

    //public GameObject groundObject;

    public float originTransform_y;

    public BoxCollider2D coll;

    public LayerMask ground;

    public bool isGround = false;

    private Camera _mainCamera;
    private float cameraOffset = 5;

    [SerializeField]
    private GameObject bullet;

    public PlayerContol(MainGame main) : base(main)
    {
        Initialize();
    }

    public override void Initialize()
    {
        _playerTransform = UnityTool.FindGameObject("Player").transform;
        rb = _playerTransform.GetComponent<Rigidbody2D>();
        //_mainCamera = UnityTool.FindGameObject("Main Camera").GetComponent<Camera>();
        coll = _playerTransform.GetComponent<BoxCollider2D>();
        playerAni = _playerTransform.GetComponent<Animator>();
        sr = _playerTransform.GetComponent<SpriteRenderer>();

        InitParam();
    }

    /// <summary>
    /// 參數初始化
    /// </summary>
    private void InitParam()
    {
        originTransform_y = _playerTransform.transform.position.y;

        speed = 3;
        jumpForce = 100;
        ground = LayerMask.NameToLayer("Ground");

        Time.timeScale = 1;

        rayUpDistance = 5;
    }

    public override void Update()
    {
        PlayerRayHandler();
        //Debug.Log(Physics2D.OverlapBox(_playerTransform.position,coll.size,10));
        //_mainCamera.transform.position = new Vector2(_playerTransform.position.x, _playerTransform.position.y + cameraOffset);
        if (coll.IsTouchingLayers(ground))
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
            playerAni.SetFloat("speed", 1);
            //New
            _playerTransform.position =
                new Vector2(_playerTransform.position.x - speed * Time.deltaTime, _playerTransform.position.y);
            //Old
            //rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            sr.flipX = true;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerAni.SetFloat("speed", 1);
            //New
            _playerTransform.position =
                new Vector2(_playerTransform.position.x + speed * Time.deltaTime, _playerTransform.position.y);
            //Old
            //rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            sr.flipX = false;

        }
        else
        {
            playerAni.SetFloat("speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            rb.AddForce(Vector2.up * jumpForce);
            playerAni.SetTrigger("jump");
            isJump = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAni.SetTrigger("attack");
            //Shoot();//暫時移除
        }
        //playerAni.SetBool("isGround", isGround);
    }

    public override void Release()
    {
        
    }

    #region 玩家事件
    private void PlayerRayHandler()
    {
        //Upward ray
        hitUpward = Physics2D.Raycast(_playerTransform.position, Vector2.up, rayUpDistance);
        if (hitUpward && hitUpward.transform.tag.Equals("InteractableGround") && isJump == true)
        {
            Debug.Log("觸發地圖互動物件");

        }
    }
    #endregion
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        /*
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
        */
    }
    /*
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
    */

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
