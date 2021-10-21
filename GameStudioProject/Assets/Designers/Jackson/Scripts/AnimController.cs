using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private PlayerMovement playerMovement;

    public GameObject bow;
    public GameObject arrow;
    public Transform bowParent;
    public Transform arrowParent;
    public int animIndex;
    public Vector3 newMovementVector;
    public Vector3 oldMovementVector;
    public Vector3 interpolated;
    public float velocity;
    public float smoothedVelocity;
    public float oldVelocity = 8f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        newMovementVector = playerMovement.animNewestTransform;
        oldMovementVector = playerMovement.animOldTransform;
        interpolated = ((oldMovementVector + newMovementVector) / 2);
        animIndex = (int)playerController.status;
        velocity = (playerMovement.groundedSpeed);
        anim.SetFloat("Velocity",(velocity));
        
        anim.SetBool("isGrounded", playerMovement.grounded);
    }

    public void ChangeAnim(int index)
    {
        anim.SetInteger("State", index);
        Debug.Log("State: " + playerController.status.ToString() + ", index: " + ((int)playerController.status));
    }

    public void SpawnBowandArrow() {
        Instantiate(bow, bowParent);
        Instantiate(arrow, arrowParent);
    }

    public void DeleteArrow() {
        Destroy(arrow);
    }

    public void DeleteBow(){
        Destroy(bow);
    }
}
