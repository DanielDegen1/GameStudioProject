using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject teleportPoint;
    private Vector3 teleportPOS;
    void Start()
    {
        teleportPOS = teleportPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

    }
    public Vector3 teleportPlayer()
    {
        Debug.Log("teleport player function called player should be moved to " + teleportPOS);
        return teleportPOS;
    }
}
