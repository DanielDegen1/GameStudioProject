using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(CinemachineImpulseSource))]
public class Pickup : MonoBehaviour
{
    private PlayerInput playerInput;
    float throwForce = 600;
    Vector3 objectPos;
    float distance;

    private CinemachineImpulseSource impulseSource;
    public bool canHold = true;
    private GameObject item;
    private GameObject tempParent;
    public bool isHolding = false;

    Ray RayOrigin;
    RaycastHit HitInfo;

    private void Start () {
        item = this.gameObject;
        //i know this sucks, remind me to improve this eventually
        tempParent = GameObject.FindGameObjectWithTag("Destination");
        playerInput = PlayerInput.Instance;
        impulseSource = GetComponent<CinemachineImpulseSource>();
        
    }

    void Update() {
        distance = Vector3.Distance (item.transform.position, tempParent.transform.position);
        if (distance>= 100f) {
            isHolding = false;
        }

        //ok ok ok i know this is a really weird way of doing this if you have a better plan pls let me know
        if (playerInput.interact) {
            if (CanPickUp()){
                    Debug.Log(HitInfo.collider.gameObject.name);
                    isHolding = true;
                    item.GetComponent<Rigidbody>().useGravity = false;
                }
        }

        if (isHolding == true) {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);
            item.transform.position = tempParent.transform.position;

            if (playerInput.Throw) {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                impulseSource.GenerateImpulse();
                item.GetComponent<Rigidbody>().detectCollisions = true;
                
                isHolding = false;
            }
        }
        else {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().detectCollisions = true;
            item.transform.position = objectPos;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (item.GetComponent<Rigidbody>().velocity.magnitude > 0.01) {
            if(collision.gameObject.tag == "Enemy") {
                //When thrown object collides with enemy do something
            }
        }
    }

    public bool CanPickUp() {
        if (isHolding) {
            return false;
        }
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, 100.0f)) {
            if(HitInfo.collider.gameObject == item) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
                return false;
            }
    }

}
