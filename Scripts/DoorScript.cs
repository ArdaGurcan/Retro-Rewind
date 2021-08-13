using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool open;
    public GameObject[] conditions;
    public bool entry;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        open = true;
        for (int i = 0; i < conditions.Length; i++)
        {
            if(!entry)
            {
                if(player.GetComponent<PlayerController>().locked)
                {
                    switch (conditions[i].tag)
                    {
                        case "Goomba":
                            if (conditions[i].GetComponent<GoombaScript>().alive)
                            {
                                open = false;
                                Debug.Log("Goomba");
                            }
                            break;
                        case "Invader":
                            if (conditions[i].GetComponent<SpriteRenderer>().enabled)
                            {
                                open = false;
                                Debug.Log("Invader");
                            }
                            break;
                        case "Button":
                            if (!conditions[i].GetComponent<Animator>().GetBool("pressed"))
                            {
                                open = false;
                                Debug.Log("Button");
                            }
                            break;
                        case "Boss":
                            if (conditions[i].GetComponent<BossScript>().hearts[0].GetComponent<SpriteRenderer>().enabled)
                            {
                                open = false;
                                Debug.Log("Button");
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    open = false;
                }
                
                //if (player.transform.position.x > transform.position.x + 0.5f) 
                //{
                //    open = true;
                //}
            }
            else if (!player.GetComponent<PlayerController>().locked)
            {
                switch (conditions[i].tag)
                {
                    case "Goomba":
                        if (!conditions[i].GetComponent<GoombaScript>().alive)
                        {
                            open = false;
                            //Debug.Log("EGoomba");
                        }
                        break;
                    case "Invader":
                        if (!conditions[i].GetComponent<SpriteRenderer>().enabled)
                        {
                            open = false;
                            //Debug.Log("EInvader");
                        }
                        break;
                    case "Crate":
                        if (!conditions[i].GetComponent<Pushable>().inDispenser)
                        {
                            open = false;
                            //Debug.Log("ECrate");
                        }
                        break;
                    case "Boss":
                        if (conditions[i].GetComponent<BossScript>().health < 3)
                        {
                            open = false;
                            Debug.Log("Button");
                        }
                        break;
                    default:
                        break;
                }
                

            }
            else
            {
                open = false;
            }
            //else if (player.transform.position.x < transform.position.x - 0.5f)
            //{
            //    open = true;
            //}


        }
        if(conditions.Length == 0)
        {
            if ((player.GetComponent<PlayerController>().locked && entry) || (!player.GetComponent<PlayerController>().locked && !entry))


                open = false;
            
        }
        else
        {
            Debug.Log(conditions.Length);

        }

        transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("open", open);

    }
}
