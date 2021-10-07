using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlat : MonoBehaviour
{
    
    public bool switchDir = false;
    float timer = 5;
    float timerReset = 5;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            switchDir = !switchDir;
            timer = timerReset;
        }

        if (switchDir == true)
        {
           
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (switchDir == false)
        {
          
            transform.Translate(Vector3.back * Time.deltaTime);
        }


    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("collide");

        if (other.gameObject==Player)
        {
            transform.parent = other.transform;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            transform.parent = null;

        }
    }

}
