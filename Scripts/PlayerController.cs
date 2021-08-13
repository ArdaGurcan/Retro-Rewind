using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using System;

public class PlayerController : MonoBehaviour
{
    public bool locked;

    public bool launching;
    public bool exit;
    public bool dead;
    public bool hasPowerUp;

    public Sprite deadSprite;
    //public GameObject restart;


    [SerializeField]
    LayerMask lmWalls;

    [SerializeField]
    float jumpVelocity = 10f;

    //[SerializeField]
    float sprintSpeed = 1.3f;

    Rigidbody2D rigid;
    SpriteRenderer sr;


    float jumpPressedRemember = 0;
    [SerializeField]
    float jumpPressedRememberTime = 0.2f;

    float groundedRemember = 0;
    [SerializeField]
    float groundedRememberTime = 0.25f;

    //[SerializeField]
    //float horizontalAcceleration = 1;


    [SerializeField]
    [Range(0, 1)]
    float cutJumpHeight = 0.4f;

    [SerializeField]
    float fallMultiplier = 3f;

    [SerializeField]
    float speed = 5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        GameObject.Find("Music").GetComponent<Animator>().SetBool("rewind", true);

    }

    void Update()
    {
                //foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        //{
        //    if (Input.GetKeyDown(kcode))
        //        Debug.Log("KeyCode down: " + kcode);


        //}
        if(dead)
        {
            launching = true;
            GetComponent<SpriteRenderer>().sprite = deadSprite;
            //restart.SetActive(true);
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (!locked && !launching)
        {
            //Vector2 v2GroundedBoxCheckPosition = (Vector2)transform.position + new Vector2(0, -0.01f);
            //Vector2 v2GroundedBoxCheckScale = (Vector2)transform.localScale + new Vector2(-0.02f, 0);
            bool bGrounded = Physics2D.OverlapBox((Vector2)transform.position + new Vector2(0, -.5f), (Vector2)transform.localScale + new Vector2(-0.3f, -.95f), 0, lmWalls);

            groundedRemember -= Time.deltaTime;
            if (bGrounded)
            {
                groundedRemember = groundedRememberTime;
            }

            jumpPressedRemember -= Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                jumpPressedRemember = jumpPressedRememberTime;
            }

            if (Input.GetButtonUp("Jump"))
            {
                if (rigid.velocity.y > 0)
                {
                    rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * cutJumpHeight);
                }


            }
            if (rigid.velocity.y < 2 && !bGrounded)
            {
                rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }

            if ((jumpPressedRemember > 0) && (groundedRemember > 0))
            {
                jumpPressedRemember = 0;
                groundedRemember = 0;
                rigid.velocity = new Vector2(rigid.velocity.x, jumpVelocity);
            }

            //float horizontalVelocity = rigid.velocity.x;
            //horizontalVelocity += Input.GetAxisRaw("Horizontal") * speed / 20;

            //if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f)
            //    horizontalVelocity *= Mathf.Pow(1f - horizontalDampingWhenStopping, Time.deltaTime * 10f);
            //else if (Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(horizontalVelocity))
            //    horizontalVelocity *= Mathf.Pow(1f - horizontalDampingWhenTurning, Time.deltaTime * 10f);
            //else
            //    horizontalVelocity *= Mathf.Pow(1f - horizontalDampingBasic, Time.deltaTime * 10f);
            

            if ((!sr.flipX && Input.GetAxisRaw("Horizontal") < 0) || (sr.flipX && Input.GetAxisRaw("Horizontal") > 0))
            {
                Flip();
            }
        }
        if (!exit)
        {
            if(!locked && !launching)
            {
                rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed * (Input.GetButton("Fire3") ? sprintSpeed : 1), rigid.velocity.y);

            }

        }
        else
        {
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        }

    }

    void Flip()
    {
        sr.flipX = !sr.flipX;
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawCube((Vector2)transform.position + new Vector2(0, -.5f), (Vector2)transform.localScale + new Vector2(-0.3f, -.95f));

    }
    void OnMouseDown()
    {
        string folderPath = "/Screenshots/";

        if (!System.IO.Directory.Exists(folderPath))
            System.IO.Directory.CreateDirectory(folderPath);

        var screenshotName =
                                "Screenshot_" +
                                System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") +
                                ".png";
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
        Debug.Log(folderPath + screenshotName);
    }
}