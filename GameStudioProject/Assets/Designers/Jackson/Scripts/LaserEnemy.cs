using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public GameObject player;
    public Transform headTransform;
    public Transform laserSource;
    private Vector3 headPos;
    public LineRenderer laser;

    public float range;
    
    void Start()
    {
        headPos = headTransform.position;
        //laser = this.GetComponent<LineRenderer>();
        laser.SetPosition(0, laserSource.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(headPos,player.transform.position) < range)
        {
            Quaternion lookRotation = Quaternion.LookRotation(player.transform.position - headTransform.position);
            headTransform.rotation = lookRotation;
            laser.SetPosition(1, player.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(headTransform.position, range);
    }
}
