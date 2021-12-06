using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushableObject : MonoBehaviour
{
    private PlayerInput input;
    RaycastHit HitInfo;
    public float pushRange = 20f;
    public float pushForce = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        input = PlayerInput.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(input.Push && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, pushRange) == true)
        {
            Debug.Log("First if statement passed");
            if(HitInfo.rigidbody == true)
            {
                Debug.Log("Second if statement passed");
                pushObject(HitInfo.rigidbody);
            }
        }
    }

    void pushObject(Rigidbody objectToPush)
    {
        // Calculate Angle Between the collision point and the player
        Vector3 dir = HitInfo.point - transform.position;
        // We then get the opposite (-Vector3) and normalize it
        dir = -dir.normalized; 
        objectToPush.AddForce(dir * pushForce);
    }
}
