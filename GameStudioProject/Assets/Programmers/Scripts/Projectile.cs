using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private bool collided;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!collided)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag != "Projectile" && col.gameObject.tag != "Player" && collided == false) {
            collided = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
