using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableShooting : MonoBehaviour
{
    public GameObject armRef;
    private AnimController animRef;
    // Start is called before the first frame update
    void Start()
    {
        animRef = armRef.GetComponent<AnimController>();
        animRef.hasBow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Shooting shootRef = other.GetComponent<Shooting>();
            shootRef.enabled = true;
            animRef.hasBow = true;

        }
    }
}
