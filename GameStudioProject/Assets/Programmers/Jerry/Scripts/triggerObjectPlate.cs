using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerObjectPlate : MonoBehaviour
{
    private bool plateTriggered = false;
    public GameObject linkedObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(plateTriggered == true && linkedObject.CompareTag("Door")) //if the object this pressure plate is tied too is tagged "Door"
        {
            doorTrigger();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Projectile")) //if the player steps on the pressure plate or shoots it with an arrow
        {
            Debug.Log("Played stepped on plate"); //do nothing since the pressure plate should not be triggerable by the player or their arrows
            //do nothing feedback?
        }
        else //if something besides the player is on the pressure plate
        {
            plateTriggered = true;
        }
    }
    private void doorTrigger()
    {
        //Potential TODO: add an animation of door opening and rework this code here
        Destroy(linkedObject); //destory the door
    }
}
