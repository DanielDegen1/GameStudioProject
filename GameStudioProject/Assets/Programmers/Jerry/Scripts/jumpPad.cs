using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    public float newJumpStrength = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO add the gravity functions to the triggerenter/exit functions in playermovement
    }

    public float updateGravityEnter()
    {
        return(newJumpStrength);
    }
    public float updateGravityExit(PlayerMovement gravityRef)
    {
        return(gravityRef.gravity = gravityRef.gravityRef);
    }
}
