using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayScript : MonoBehaviour
{
    public AudioSource PlaySound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlaySound.Play();
        }
    }
}

