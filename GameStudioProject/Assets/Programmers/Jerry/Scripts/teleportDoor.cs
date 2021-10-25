using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //TODO move this to the player script 
        //TODO when the player moves into the collider get this script component from the object 
        //TODO set the player position to the gameobject stored in this script
        //PROBABLY call a function in here to move the player
    }
}
