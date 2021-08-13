using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionScript : MonoBehaviour
{
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.hasPowerUp && Mathf.Round(transform.GetChild(0).position.y) == 0)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("out", true);
        }
    }
}
