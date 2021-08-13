using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour
{
    public Animator cover;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && GameObject.FindGameObjectWithTag("Boss").GetComponent<BossScript>().health < 3)
        {
            collision.GetComponent<PlayerController>().launching = true;

            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(500 * Time.deltaTime, 720 * Time.deltaTime), ForceMode2D.Impulse);
            collision.GetComponent<PlayerController>().launching = true;
            cover.SetBool("open", true);
        }
    }
}
