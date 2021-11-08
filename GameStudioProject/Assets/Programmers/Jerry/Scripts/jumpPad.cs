using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    public float gravityReduction = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO add the gravity functions to the triggerenter/exit functions in playermovement
    }

    private void updateGravityEnter(PlayerMovement gravityRef)
    {
        gravityRef.gravity -= gravityReduction;
    }
    private void updateGravityExit(PlayerMovement gravityRef)
    {
        gravityRef.gravity = gravityRef.gravityRef;
    }
}
