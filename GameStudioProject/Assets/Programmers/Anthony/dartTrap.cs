using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dartTrap : MonoBehaviour
{
    public GameObject bullet;
    public float spawnDistance = 3.0f;
    private GameObject current;
    public float spawnTimer = 5;
    private float spawnTimerReset;
    public float speed = 8;
    public float despawnTimer = 7;
    private float despawnTimerReset;

    Rigidbody dartRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimerReset = spawnTimer;
        despawnTimerReset = despawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            
            GameObject current = Instantiate(bullet, transform.position + spawnDistance * transform.forward, transform.rotation);        
            spawnTimer = spawnTimerReset;
        }

        if(despawnTimer < 0)
        {
            Destroy(current);
        }

        dartRigidbody = current.GetComponent<Rigidbody>();
        dartRigidbody.velocity = transform.forward * speed;


    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(current);
    }






}
