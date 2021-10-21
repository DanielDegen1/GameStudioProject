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
    public float velocity;
    public float oldVelocity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animIndex = (int)playerController.status;
        velocity = Mathf.SmoothDamp(oldMovementVector.magnitude, newMovementVector.magnitude, ref oldVelocity, 0.3f);
        anim.SetFloat("Velocity",(velocity));
        Debug.Log("Velocity: " + velocity);
        anim.SetBool("isGrounded", playerMovement.grounded);
    }

    public void ChangeAnim(int index)
    {
        anim.SetInteger("State", index);
        Debug.Log(anim.GetInteger("State"));
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
