using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private PlayerMovement playerMovement;
    private PlayerInput input;
    private Shooting shootController;

    public GameObject bowPrefab;
    public GameObject arrowPrefab;

    private GameObject bow;
    private GameObject arrow;

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
        input = playerMovement.gameObject.GetComponent<PlayerInput>();
        shootController = playerMovement.gameObject.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        newMovementVector = playerMovement.animNewestTransform;
        oldMovementVector = playerMovement.animOldTransform;
        interpolated = ((oldMovementVector + newMovementVector) / 2);
        animIndex = (int)playerController.status;
        velocity = (playerMovement.groundedSpeed);

        
        if (input.shoot)
        {
            anim.SetTrigger("Fire");
        }
        

        anim.SetFloat("Velocity",(velocity));
        
        anim.SetBool("isGrounded", playerMovement.grounded);
    }

    public void ChangeAnim(int index)
    {
        anim.SetInteger("State", index);
        //Debug.Log("State: " + playerController.status.ToString() + ", index: " + ((int)playerController.status));
    }

    public void SpawnBowandArrow() {
        if (bow == null && arrow == null)
        {
            bow = Instantiate(bowPrefab, bowParent);
            arrow = Instantiate(arrowPrefab, arrowParent);
        }
        else
        {
            bow.SetActive(true);
            arrow.SetActive(true);
        }
    }

    public void DeleteArrow() {
        arrow.SetActive(false);
        Destroy(arrow);
        shootController.ShootProjectile();
    }

    public void DeleteBow(){
        bow.SetActive(false);
        Destroy(bow);
    }
}
