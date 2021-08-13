using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Music"))
        {
            Destroy(GameObject.Find("Music"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
