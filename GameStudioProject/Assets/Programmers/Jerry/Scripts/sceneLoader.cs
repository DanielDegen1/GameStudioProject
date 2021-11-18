using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{

    public string levelName;
   // [HideInInspector]
    public bool levelComplete = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Scene Loader trigger entered");
        if (other.gameObject.CompareTag("Next Level"))
        {

            // Loading the scene from it's name
            SceneManager.LoadScene(levelName);
            Debug.Log("New Scene should load");
        }
    }
}
