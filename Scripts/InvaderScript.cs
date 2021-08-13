using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderScript : MonoBehaviour
{
    public float delay = 5f;
    public GameObject playerBullet;
    public float bulletSpeed = 5f;
    public bool shot;
    public bool die;
    public bool visible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay < 0 && !shot)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            visible = true;
            if(delay < -.2f)
            {
                shot = true;
                playerBullet.GetComponent<BulletScript>().parent = this;
                playerBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                playerBullet.GetComponent<SpriteRenderer>().enabled = true;
            }
            
            
        }

        if(!visible && die)
        {
            GetComponent<SpriteRenderer>().enabled = false;

        }
        else if(visible)
        {
            GetComponent<SpriteRenderer>().enabled = true;

        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.CompareTag("Bullet"))
    //    {
    //        other.GetComponent<SpriteRenderer>().enabled = false;
    //        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    //    }
    //}
}
