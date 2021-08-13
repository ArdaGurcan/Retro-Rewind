using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject[] rockets;
    public float interval = 1f;
    public float health;
    public GameObject cover;
    public PlayerController player;
    public SpriteRenderer[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //cover.GetComponent<Animator>().SetBool("rewind", TimeBody.rewind);
        //if (player.locked)
        //{
            
        //    if (hearts[0].GetComponent<SpriteRenderer>().enabled)
        //    {
        //        cover.GetComponent<Animator>().SetBool("open", true);

        //    }
        //    else
        //    {
        //        cover.GetComponent<Animator>().SetBool("open", false);
        //        for (int i = 0; i < rockets.Length; i++)
        //        {
        //            Destroy(rockets[i]);
        //        }
        //    }

        //}
        //else
        //{

        if(!player.locked)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i >= health)
                {
                    hearts[i].enabled = false;
                }
                else
                {
                    hearts[i].enabled = true;


                }
            }
        }
           
        //}
        
        if (health > 0 && player.transform.position.x > -3.5f)
        {
            rockets[0].GetComponent<BoxCollider2D>().enabled = true;
            rockets[1].GetComponent<BoxCollider2D>().enabled = true;

            interval -= Time.deltaTime;
            if (interval <= 0)
            {
                rockets[Random.Range(0, 2)].GetComponent<RocketScript>().Launch();
                interval = 1f;
            }
        }
        else
        {
            //rockets[0].GetComponent<BoxCollider2D>().enabled = false;
            //rockets[1].GetComponent<BoxCollider2D>().enabled = false;

        }

        if(TimeBody.rewind && player.transform.position.x > 2.5f && hearts[0].enabled)
        {
            cover.GetComponent<Animator>().SetBool("open", true);
        }
        else if(TimeBody.rewind)
        {
            cover.GetComponent<Animator>().SetBool("open", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && cover.GetComponent<Animator>().GetBool("open"))
        {
            health++;
            cover.GetComponent<Animator>().SetBool("open", false);
            GetComponent<Animator>().SetBool("pressed", true);
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.left * 5;

            //collision.GetComponent<PlayerController>().locked = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("pressed", false);
            collision.GetComponent<PlayerController>().launching = false;

        }
    }
}