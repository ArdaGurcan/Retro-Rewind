using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuItem : MonoBehaviour
{
    string txt;
    string selectedTxt;

    Text text;
    Text realText;

    private void Start()
    {
        text = GetComponent<Text>();
        realText = transform.GetChild(0).GetComponent<Text>();
        txt = text.text;
        selectedTxt = txt + " >>";
    }

    public void MouseOver()
    {
        text.text = selectedTxt;
        text.color = new Color(0, 0, 0, 1);
        realText.text = selectedTxt;
    }

    public void MouseExit()
    {
        text.text = txt;
        text.color = new Color(0, 0, 0, 0);
        realText.text = txt;

    }

    public void Play()
    {
        SceneManager.LoadScene(2);

    }
    public void Credits()
    {
        SceneManager.LoadScene(1);

    }
    public void Back()
    {
        SceneManager.LoadScene(0);

    }
    public void Quit()
    {
        Application.Quit();

    }
}
