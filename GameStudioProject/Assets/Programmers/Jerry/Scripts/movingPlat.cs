using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlat : MonoBehaviour
{

    public GameObject[] pivotPoints;
    public float platSpeed = 1; //speed the platform will move
    public float delayTimer; //how long until platform moves again after stopping

    private float tolerance;
    private int pivotCounter = 0;
    private Vector3 currentTarget;
    private bool DEBUG = false; //if you dont want the debug.log spammed set this to false
    private float delayStart;
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pivotPoints[0].transform.position;
        tolerance = platSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position != currentTarget) //move the platform towards the target
        {
            movePlatform();
        }
        else //once the platform has reached its target 
        {
            if (DEBUG == true)
            {
                Debug.Log("Platform has reached pivot point #" + pivotCounter);
            }
            updateTarget(); //set currentTarget = the position of the next pivot point
        }
    }
    private void updateTarget()
    {
        if(Time.time-delayStart > delayTimer)
        {
            NextPlatform();
        }
    }
    private void NextPlatform()
    {
        pivotCounter++;
        if (pivotCounter >= pivotPoints.Length)
        {
            pivotCounter = 0;
        }
        currentTarget = pivotPoints[pivotCounter].transform.position;
    }
    private void movePlatform()
    {
        Vector3 heading = currentTarget - transform.position;
        transform.position += (heading / heading.magnitude) * platSpeed * Time.deltaTime;
        if(heading.magnitude < tolerance)
        {
            transform.position = currentTarget;
            delayStart = Time.time;
        }
    }
}
