using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int collisions = 0;
    Animator animator;
    public bool pressed;
    public bool forcePressed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapBox(transform.position - new Vector3(0,.3f), new Vector2(.75f,.17f),0) || forcePressed)
        {
            //Debug.Log(Physics2D.OverlapBox(transform.position - new Vector3(0, .3f), new Vector2(.75f, .17f), 0));
            animator.SetBool("pressed", true);
            pressed = true;
        }
        else if(!forcePressed)
        {
            animator.SetBool("pressed", false);
            pressed = false;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    collisions++;

    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    pressed = true;
    //    Debug.Log(collision.gameObject);
    //}
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    pressed = false;
    //}
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - new Vector3(0, .3f), new Vector3(-.75f, .17f));
    }
}
