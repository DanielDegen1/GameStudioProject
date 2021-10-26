using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




    }

    void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("collide");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            Debug.Log("collide");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.tag == "boulder")
        {
            Debug.Log("boulder");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.tag == "temp")
        {
            //Debug.Log("temp");
         
        }
    }

}
