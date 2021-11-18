using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyArrow : MonoBehaviour
{
    public float despawnTimer = 5;
    private float timer = 0;
    private bool landed = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(landed == true)
        {
            timer += Time.deltaTime;
        }

        if(timer >= despawnTimer)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        landed = true;   
    }
}
