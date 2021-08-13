using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaScript : MonoBehaviour
{
    public bool alive = false;
    Animator animator;
    public bool playerEntered;
    public float speed = 2f;
    public LayerMask obstacle;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (!alive)
        {
            Collider2D other = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y + 0.4f), new Vector2(0.8f, 0.1f), 0);
            if (other && other.CompareTag("Player"))
            {
                playerEntered = true;

            }
            else if((!other || other.CompareTag("Player")) && playerEntered)
            {
                //Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y);
                if(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    alive = true;

                }
                playerEntered = false;
            }

        }
        else
        {


            Collider2D other = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.12f), new Vector2(.8f, 0.7f), 0);
            if (other && other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().dead = true;
                //other.GetComponent<SpriteRenderer>().flipY = true;


            }
            //else if(other)
            //{
            //    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            //}

            if(Physics2D.Raycast(transform.position + transform.right * 0.51f, transform.right, .1f,obstacle))
            {
                transform.Rotate(0, 180, 0);
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;

            }
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;// + GetComponent<Rigidbody2D>().velocity.y * transform.up;
        }
            
        GetComponent<Rigidbody2D>().simulated = alive;
        animator.SetBool("alive", alive);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + new Vector3(0,0.4f), new Vector3(0.8f, 0.1f, 1));
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.12f), new Vector2(.7f, .5f));
        Gizmos.DrawRay(transform.position+ transform.right*0.6f, transform.right*0.7f);
        
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.collider.CompareTag("Player"))
    //    {
    //        collision.collider.GetComponent<PlayerController>().dead = true;
    //    }
    //    //else
    //    //{
    //    //    transform.Rotate(0, 180, 0);

    //    //}
    //    //Debug.Log(collision.collider.tag);
    //}
}
