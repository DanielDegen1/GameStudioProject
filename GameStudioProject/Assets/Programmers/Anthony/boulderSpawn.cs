using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderSpawn : MonoBehaviour
{
    public float timerReset = 5;
    public float timer = 5;
    public GameObject Boulder;
    
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
            Instantiate(Boulder, transform.position, transform.rotation);
            timer = timerReset;           
        }
    }
}
