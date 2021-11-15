using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springPad : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void bouncePlayer(float bounceTime)
    {
        Debug.Log("player should be bounced");

        while(bounceTime > 0)
        {
            Debug.Log("player is being bounced");
            player.transform.position += Vector3.up;
            bounceTime--;
        }
    }
}
