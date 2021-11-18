using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{

    //public string levelName;
   // [HideInInspector]
    public bool levelComplete = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Scene Loader trigger entered");
        if (other.gameObject.CompareTag("Next Level"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

            Debug.Log("New Scene should load");
        }
    }
}
