using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction { NONE, UP, DOWN, LEFT, RIGHT };

public class PlayerController : MonoBehaviour
{
    private BoxCollider2D box2D;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr_render;

    private int runningID;
    private int jumpingID;

    private Vector2 spdVector;
    private Vector2 prevSpd;

    private Direction moveDir;

    private bool isRunning;
    private bool isJumping;
    private bool wasJumping;
    private bool jumpPerformed;
    private bool canWallJump;
    private Direction jumpDir;
    private float doublejump;

    public float moveSpeed = 4;
    public float jumpSpeed = 300;

    public AudioSource Jump;
    public AudioSource music;

    //for knockback
    public static PlayerController instance;

    public GameObject[] Teleports;

    internal void FlipX(bool v)
    {
        spr_render.flipX = v;
    }

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        box2D = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr_render = GetComponent<SpriteRenderer>();
    
        runningID = Animator.StringToHash("isMoving");
        jumpingID = Animator.StringToHash("isJumping");

        isRunning = false;
        isJumping = true;
        wasJumping = false;
        jumpPerformed = true;
        canWallJump = false;

        moveDir = Direction.NONE;
        music.Play();
    }

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };

    private int i;
    // Update is called once per frame
    void Update()
    {

        for (i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                if (Teleports[i] != null)
                {
                    this.transform.position = Teleports[i].transform.position;
                }
            }
        }

            moveDir = Direction.NONE;
        isRunning = false;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            isRunning = true;
            moveDir = Direction.RIGHT;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            isRunning = true;
            moveDir = Direction.LEFT;
        }

        if (!isJumping || canWallJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpPerformed = false;
                isJumping = true;
                Jump.Play();
            }
        }
        
        anim.SetBool(runningID, isRunning);
        if (wasJumping != isJumping)
        {
            anim.SetBool(jumpingID, isJumping);
        }
        wasJumping = isJumping;
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;
        spdVector.y = rb2d.velocity.y;
        switch (moveDir)
        {
            default:
                spdVector.x = 0;
                break;
            case Direction.RIGHT:
                spdVector.x = moveSpeed * delta;
                break;
            case Direction.LEFT:
                spdVector.x = -moveSpeed * delta;
                break;
        }
        rb2d.velocity = spdVector;

        if (isJumping && !jumpPerformed)
        {
            jumpPerformed = true;
            float jumpSpdX = 0;
            if (jumpDir == Direction.LEFT)
            {
                jumpSpdX = -jumpSpeed * delta;
                spr_render.flipX = true;
            }
            else if (jumpDir == Direction.RIGHT)
            {
                jumpSpdX = jumpSpeed * delta;
                spr_render.flipX = false;
            }
            rb2d.AddForce(new Vector2(jumpSpdX, jumpSpeed * delta));
        }
    }

    private bool checkRaycastWithScenario(RaycastHit2D[] hits)
    {
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Scenario")
                {
                    return true;
                }
                if (hit.collider.gameObject.tag == "Plataforma")
                {
                    jumpPerformed = true;
                    isJumping = false;
                    return true;
                }
            }
        }
        return false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Scenario" || collision.gameObject.tag == "Plataforma")
        {
            if (isJumping)
            {
                bool col1 = false;
                bool col2 = false;
                bool col3 = false;

                float center_x = (box2D.bounds.min.x + box2D.bounds.max.x) / 2;
                float center_y = (box2D.bounds.min.y + box2D.bounds.max.y) / 2;
                Vector2 bottomCenterPos = new Vector2(center_x, box2D.bounds.min.y);
                Vector2 bottomLeftPos = new Vector2(box2D.bounds.min.x, box2D.bounds.min.y);
                Vector2 bottomRightPos = new Vector2(box2D.bounds.max.x, box2D.bounds.min.y);

                Vector2 leftPos = new Vector2(box2D.bounds.min.x, center_y);
                Vector2 rightPos = new Vector2(box2D.bounds.max.x, center_y);

                RaycastHit2D[] hits = Physics2D.RaycastAll(bottomCenterPos, -Vector2.up, 2);
                col1 = checkRaycastWithScenario(hits);

                if (!col1)
                {
                    hits = Physics2D.RaycastAll(bottomLeftPos, -Vector2.up, 2);
                    col2 = checkRaycastWithScenario(hits);
                }
                if (!col2)
                {
                    hits = Physics2D.RaycastAll(bottomRightPos, -Vector2.up, 2);
                    col3 = checkRaycastWithScenario(hits);
                }
                if (col1 || col2 || col3) { isJumping = false; }

                hits = Physics2D.RaycastAll(leftPos, -Vector2.right, 10);
                bool wallLeft = checkRaycastWithScenario(hits);

                hits = Physics2D.RaycastAll(rightPos, Vector2.right, 10);
                bool wallRight = checkRaycastWithScenario(hits);

                if (wallLeft || wallRight)
                {
                    if (wallLeft)
                    {
                        jumpDir = Direction.RIGHT;
                    }
                    if (wallRight)
                    {
                        jumpDir = Direction.LEFT;
                    }
                    canWallJump = false;
                }
            }
        }
    }

    //for knockback
    public IEnumerator Knowckback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb2d.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DoubleJump")
        {
            Destroy(collision.gameObject);
            doublejump++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slimos" || collision.gameObject.tag == "Pigero" || collision.gameObject.tag == "SlimoGreen" || collision.gameObject.tag == "SlimoYellow" || collision.gameObject.tag == "PigeroGreen" || collision.gameObject.tag == "PigeroYellow" || collision.gameObject.tag == "PigeroRed" || collision.gameObject.tag == "SlimoRed" || collision.gameObject.tag == "Thundorf" || collision.gameObject.tag == "Rayo")
        {
            anim.SetBool("dmged", true);
        }

        if (collision.gameObject.tag == "Plataforma")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slimos" || collision.gameObject.tag == "Pigero" || collision.gameObject.tag == "SlimoGreen" || collision.gameObject.tag == "SlimoYellow" || collision.gameObject.tag == "PigeroGreen" || collision.gameObject.tag == "PigeroYellow" || collision.gameObject.tag == "PigeroRed" || collision.gameObject.tag == "SlimoRed" || collision.gameObject.tag == "Thundorf" || collision.gameObject.tag == "Rayo")
        {
            anim.SetBool("dmged", false);
        }

        if (collision.gameObject.tag == "Plataforma")
        {
            transform.parent = null;
        }
    }
}
