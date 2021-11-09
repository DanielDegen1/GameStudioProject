using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dartTrap : MonoBehaviour
{
    public GameObject bullet;
    public float spawnDistance = 3.0f;
    private GameObject current;
    public float spawnTimer = 5;
    private float spawnTimerReset = 5;
    public float speed = 8;

    private despawnTimer despawnRef;
    Rigidbody dartRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimerReset = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime; //decrement the amount of time set between spawning objects

        if (spawnTimer < 0) //once that spawn time hits 0
        {
            
            current = Instantiate(bullet, transform.position + spawnDistance * transform.forward, transform.rotation); //instantiate a bullet/dart   
            despawnRef = current.GetComponent<despawnTimer>();  
            despawnRef.DoNotDestroy = false;
            spawnTimer = spawnTimerReset; //reset the spawntimer
        }

        dartRigidbody = current.GetComponent<Rigidbody>(); //store a reference to the instantiated rigidbody
        dartRigidbody.velocity = transform.forward * speed; //move the dart forward relative to the speed defined in the inspector
    }

    






}
