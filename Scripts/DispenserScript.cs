using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenserScript : MonoBehaviour
{
    public bool open = true;
    public LayerMask crateMask;
    public float liftSpeed = 5f;

    void Update()
    {
        if(open && Physics2D.Raycast(transform.position, -transform.up, 15, crateMask))
        {
            
            GameObject crate = Physics2D.Raycast(transform.position, -transform.up, 15, crateMask).collider.gameObject;
            //Debug.Log(crate);
            crate.GetComponent<Rigidbody2D>().gravityScale = 0;
            crate.GetComponent<Rigidbody2D>().velocity = Vector2.up * liftSpeed + Vector2.right *(transform.position.x - crate.transform.position.x);

        }

        
        transform.GetChild(0).gameObject.SetActive(!open);
        transform.GetChild(1).gameObject.SetActive(open);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if(other.gameObject.layer == 10)
        {
            open = false;
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            other.GetComponent<Pushable>().inDispenser = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 10)
        {
            other.GetComponent<Pushable>().inDispenser = false;

        }
    }
}
