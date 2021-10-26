using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlatform : MonoBehaviour
{
    private Vector2 p;
    private GameObject Player;
    public GameObject Platform;
    public float platformRespawn = 5;
    public float platformReset = 5;
    public float timerReset = 3;
    public float timer = 3;
    private bool timerStart = false;
    private bool respawntimerStart = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        p = this.transform.position;
        platformReset = platformRespawn;
        timerReset = timer;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, Player.transform.position) <= 1)
        {
            
            //timerStart = true;
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
            Platform.SetActive(false);
        }

        if (respawntimerStart == true)
        {
            
            platformRespawn -= Time.deltaTime;
        }

        if (platformRespawn < 0)
        {
            
            respawntimerStart = false;
            Platform.SetActive(true);
            platformRespawn = platformReset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("temp");
            timerStart = true;
        }
    }



}
