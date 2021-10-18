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

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animIndex = (int)playerController.status;
        anim.SetFloat("Velocity",(animIndex*Time.deltaTime)*100);
        Debug.Log("Velocity: " + anim.GetFloat("Velocity"));
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
