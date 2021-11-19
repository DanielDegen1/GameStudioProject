using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalScene : MonoBehaviour
{

    //public string levelName;
    [HideInInspector]
    public bool levelComplete = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Scene Loader trigger entered");
        if (other.gameObject.tag == ("Player"))
        {
            SceneManager.LoadScene(0);
;

            Debug.Log("New Scene should load");
        }
    }
}