using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderhit : MonoBehaviour
{
    public float boulderDespawnTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boulderDespawnTime -= Time.deltaTime;

        if (boulderDespawnTime < 0)
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //respawn Player
        }
    }
}
