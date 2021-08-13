using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float speed = 8f;
    public Vector2 startingPosition;
    public LayerMask wall;
    public SpriteRenderer sp;
    public Rigidbody2D rb;
    //public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //ps = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!TimeBody.rewind)
        {
            if (rb.velocity == Vector2.zero)
            {
                sp.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;

            }

            if (transform.position.x > 5.36f)
            {
                sp.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;

                rb.velocity = Vector2.zero;
                transform.position = startingPosition;
            }
        }
        
    }

    public void Launch()
    {
        if(!TimeBody.rewind)
        {
            sp.enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            //ps.Play();
            transform.position = new Vector3(Physics2D.Raycast(transform.position, -transform.right, 30, wall).point.x + 0.5f, transform.position.y);
            Debug.Log(Physics2D.Raycast(transform.position, -transform.right, 30, wall).collider.gameObject);
            rb.velocity = Vector2.right * speed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!TimeBody.rewind)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerController>().dead = true;
                sp.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                rb.velocity = Vector2.zero;
                transform.position = startingPosition;
                //ps.Play();

            }
            if (collision.CompareTag("Boss"))
            {
                sp.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                rb.velocity = Vector2.zero;
                transform.position = startingPosition;
            }
                
        }
       
    }

}
