using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dartTrap : MonoBehaviour
{
    public GameObject bullet;
    public float spawnDistance = 3.0f;
    private GameObject current;
    public float timer = 5;
    public float timerReset = 5;
    public float speed = 8;

    Rigidbody dartRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {;
            
            current = Instantiate(bullet, transform.position + spawnDistance * transform.forward, transform.rotation);        
            timer = timerReset;
        }

        dartRigidbody = current.GetComponent<Rigidbody>();
        dartRigidbody.velocity = transform.forward * speed;
    }

    






}
