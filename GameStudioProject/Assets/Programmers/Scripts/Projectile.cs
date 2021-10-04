using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private bool collided;

    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag != "Projectile" && col.gameObject.tag != "Player" && collided == false) {
            collided = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
