using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GetComponent<AudioSource>().volume = 0.1f;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
