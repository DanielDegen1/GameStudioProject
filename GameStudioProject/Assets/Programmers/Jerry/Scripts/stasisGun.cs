using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stasisGun : MonoBehaviour
{
    PlayerInput input;
    RaycastHit hit;
    public int stasisRange = 10; // the current range of the stasis gun
    public float stasisDuration = 10.0f; //the current duration of the stasis effect
    private GameObject stasisObject; //stores the object that is currently frozen in stasis
    private Rigidbody stasisRigid; //stores reference to the stasis object's rigidbody
    private bool stasisActive = false; //flag variable for whether an object is currently frozen
    private float timeCounter = 0.0f; //stores the time that has currently passed while an object is stasis'd


    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(input.Stasis && stasisActive == false)
        {
            Stasis();
        }
        if(stasisActive == true)
        {
            StasisCounter();
        }
    }
    void Stasis() //function to handle the stasis input
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity); //REMINDER change infinity to range once interating is done
        if (hit.rigidbody == true)
        {
            stasisObject = hit.collider.gameObject;
            stasisRigid = GetComponent<Rigidbody>();
            stasisActive = true;
            stasisRigid.useGravity = false;
            Debug.Log("stasis hit");
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
            stasisRigid.useGravity = true;
            stasisActive = false;
            timeCounter = 0.0f;
        }
    }
}
