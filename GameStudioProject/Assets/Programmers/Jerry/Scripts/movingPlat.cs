using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlat : MonoBehaviour
{
    /*
    public float positiveXOffset;
    public float positiveYOffset;
    public float positiveZOffset;
    public float negativeXOffset;
    public float negativeYOffset;
    public float negativeZOffset;
    */
    public GameObject[] pivotPoints;
    private int pivotCounter = 0;
    private Vector3 currentTarget;
    private bool DEBUG = true; //if you dont want the debug.log spammed set this to false
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pivotPoints[0].transform.position;
        if (DEBUG == true)
        {
            Debug.Log("Moving Platform script attached :)");

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, 0.1f);
        if (transform.position == currentTarget) //once the platform has reached its target 
        {
            if (DEBUG == true)
            {
                Debug.Log("Platform has reached pivot point #" + pivotCounter);
            }
            pivotCounter++; //increment the pivot tracker
            updateTarget(); //set currentTarget = the position of the next pivot point
        }
    }
    private void updateTarget()
    {
        if (DEBUG == true)
        {
            Debug.Log("Target is being updated to pivot position #" + pivotCounter);
        }
        if(pivotCounter >= pivotPoints.Length - 1)
        {
            Debug.Log("Target is now the first pivot point");
            pivotCounter = 0;
        }
        currentTarget = pivotPoints[pivotCounter].transform.position;
    }
}
