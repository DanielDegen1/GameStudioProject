using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushableObject : MonoBehaviour
{
    private PlayerInput input;
    RaycastHit HitInfo;
    public float pushRange = 20f;
    public float pushForce = 1000f;
    [SerializeField]
    public GameObject pushText;
    private bool pushable = false;
    // Start is called before the first frame update
    void Start()
    {
        input = PlayerInput.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        pushable = CanPush();
        if(pushable)
        {
            pushText.SetActive(true);
            Debug.Log("First if statement passed");
            if(input.Push)
            {
                Debug.Log("Second if statement passed");
                pushObject(HitInfo.rigidbody);
            }
        }
        else
        {
            pushText.SetActive(false);
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

    public bool CanPush()
    {
        Debug.Log("Can push called");
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, pushRange))
        {
            if (HitInfo.rigidbody)
            {
                Debug.Log("can push object");
                return true;
            }
            else
            {
                Debug.Log("can not push object");

                return false;
            }
        }
        else
        {
            Debug.Log("can not push object");

            return false;
        }
    }
}
