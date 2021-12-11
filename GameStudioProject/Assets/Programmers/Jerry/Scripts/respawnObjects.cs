using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class respawnObjects : MonoBehaviour
{
    private Vector3 respawnPOS;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        respawnPOS = this.transform.position;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Death"))
        {
            respawnOrb(respawnPOS);
        }
    }

    private void respawnOrb(Vector3 newPOS)
    {
        this.transform.position = newPOS;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
