using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stasisGun : MonoBehaviour
{
    PlayerInput input;
    Shooting crosshair;
    RaycastHit hit;
    public int stasisRange = 10; // the current range of the stasis gun
    public float stasisDuration = 10.0f; //the current duration of the stasis effect
    private Rigidbody stasisRigid; //stores reference to the stasis object's rigidbody for renabling it's physics
    private bool stasisActive = false; //flag variable for whether an object is currently frozen
    private float timeCounter = 0.0f; //stores the time that has currently passed while an object is stasis'd


    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.GetComponent<PlayerInput>();
        crosshair = gameObject.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.Stasis && stasisActive == false)
        {
            Debug.Log("Player Hit Stasis Button While Stasis was not active");
            Stasis();
        }
        if(stasisActive == true)
        {
            StasisCounter();
        }
    }
    void Stasis() //function to handle the stasis input
    {
        if (Physics.Raycast(crosshair.cam.transform.position, crosshair.cam.transform.forward, out hit) && hit.rigidbody == true)
        {
            stasisRigid = hit.rigidbody;
            stasisActive = true;
            hit.rigidbody.isKinematic = true;
            Debug.Log("stasis hit rigid body");
        }
        else if (hit.rigidbody != true)
        {
            Debug.Log("Targeted Object does not have a rigidbody.");
        }    
        else
        {
            Debug.Log("stasis missed");
            //missed stasis feedback
        }
               
    }
    void StasisCounter() //function to handle the object that is currently frozen in time
    {
        if(timeCounter <= stasisDuration)
        {
            timeCounter += Time.deltaTime;
        }
        else
        {
            Debug.Log("Stasis has worn off");
            stasisRigid.isKinematic = false;
            stasisActive = false;
            timeCounter = 0.0f;
        }
    }
}
