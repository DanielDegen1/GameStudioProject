using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceDisable : MonoBehaviour
{
    

    public GameObject voice;
    // Start is called before the first frame update
    void Start()
    {
        voice.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.m_Paused == true)
        {
            Debug.Log("dis");
            voice.SetActive(false);
        }
        else
        {
            voice.SetActive(true);
        }
    }
}
