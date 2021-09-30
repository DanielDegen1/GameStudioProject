using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlatform : MonoBehaviour
{
    
    private GameObject Player;
    public GameObject Platform;
    private float platformRespawn = 5;
    private float platformReset = 5;
    private float timerReset = 3;
    private float timer = 3;
    private bool timerStart = false;
    private bool respawntimerStart = false;
   

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

        //should check for collision w/ player instead but wasnt working 
        if (Vector3.Distance(transform.position, Player.transform.position) <= 1)
        {
            Debug.Log("p");
            timerStart = true;
        }

        if (timerStart == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            timerStart = false;
            timer = timerReset;
            respawntimerStart = true;
            transform.position = transform.position * -1;
        }

        if (respawntimerStart == true)
        {
            Debug.Log("r");
            platformRespawn -= Time.deltaTime;
        }

        if (platformRespawn < 0)
        {

            respawntimerStart = false;
            transform.position = transform.position * -1;
            platformRespawn = platformReset;
        }

    }

   
}
