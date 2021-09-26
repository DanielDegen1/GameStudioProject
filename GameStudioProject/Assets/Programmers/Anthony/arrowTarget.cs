using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowTarget : MonoBehaviour
{
    //create for each obstacle type
    targetTempPlatform tempplatform;
    targetMovingPlat movingplatform;

    public GameObject linkedObstacle;
    private bool targethit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targethit == true && linkedObstacle.tag=="temp")
        {
            tempplatform = linkedObstacle.GetComponent<targetTempPlatform>();
            tempplatform.active = true;
        }

        if (targethit == true && linkedObstacle.tag == "moving")
        {
            movingplatform = linkedObstacle.GetComponent<targetMovingPlat>();
            movingplatform.active = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("hit");
            targethit = true;
        }
    }


}
