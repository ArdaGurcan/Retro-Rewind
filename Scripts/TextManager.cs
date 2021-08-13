using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text play;
    public Text playShadow;
    public Text time;
    public Text timeShadow;
    public GameObject restart;
    float timeRemaining = 120f;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.dead)
        {
            if (timeRemaining > Time.deltaTime && timeRemaining < 121f - Time.deltaTime)
            {
                if (!TimeBody.rewind)
                {
                    timeRemaining -= Time.deltaTime;
                    play.text = "REWIND <<";
                    playShadow.text = "REWIND <<";

                }
                else
                {
                    timeRemaining += Time.deltaTime;
                    play.text = "PLAY >>";
                    playShadow.text = "PLAY >>";
                }
                time.text = Format(Mathf.Floor(timeRemaining / 60)) + ":" + Format(Mathf.Floor(timeRemaining % 60));
                timeShadow.text = time.text;
            }
            else
            {
                if(timeRemaining < Time.deltaTime)
                {
                    time.color = new Color(1, .2f, .2f, 1);
                }

                restart.SetActive(true);


            }
        }
        else
        {
            restart.SetActive(true);
        }

    }

    string Format(float n)
    {
        return (n < 10 ? "0" : "") + n;
    }
}
