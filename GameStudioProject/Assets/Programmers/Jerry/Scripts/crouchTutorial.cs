using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouchTutorial : MonoBehaviour
{
    public GameObject crouchText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            crouchText.SetActive(true);
        }
    }
}
