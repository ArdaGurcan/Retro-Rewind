using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TriggerScript : MonoBehaviour
{
    public bool isExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(isExit)
            {
                if(collision.GetComponent<PlayerController>().locked)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                TimeBody.rewind = true;
            }
        }
    }
}
