using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    public bool inDispenser;


    private void Update()
    {
        if(GetComponent<Rigidbody2D>().simulated)
        {
            GameObject player = null;
            Collider2D[] other = Physics2D.OverlapBoxAll(transform.position, new Vector2(1.5f, .9f), 0);
            for (int i = 0; i < other.Length; i++)
            {
                if (other[i].CompareTag("Player"))
                {
                    player = other[i].gameObject;
                }
            }
            if (player && player.CompareTag("Player"))
            {
                if (player.GetComponent<Rigidbody2D>().velocity.x * (transform.position.x - player.transform.position.x) < 0)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);

                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                    GetComponent<Rigidbody2D>().isKinematic = true;

                }

            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

                GetComponent<Rigidbody2D>().isKinematic = false;

            }
        }
        
        //else if(other && other.GetComponent<Rigidbody2D>().velocity.x * (transform.position.x - other.transform.position.x) > 0)
        //{
        //    //transform.SetParent(null);
        //    GetComponent<Rigidbody2D>().isKinematic = true;
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.collider.tag);
        



    }
}
