using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dTrap : MonoBehaviour
{
    public GameObject bullet;
    float spawnDistance = 1.0f;
    public GameObject current;
    float timer = 5;
    float timerReset = 5;

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
        {
            ;
            Destroy(current);
            current = Instantiate(bullet, transform.position + spawnDistance * transform.forward, transform.rotation);
            dartRigidbody = current.GetComponent<Rigidbody>();
            timer = timerReset;
        }

        dartRigidbody.velocity = transform.forward * 3;
    }


}
