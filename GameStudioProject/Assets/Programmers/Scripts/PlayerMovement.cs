using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : InterpolatedTransform
{
    public float walkSpeed = 4.0f;
    public float runSpeed = 8.0f;
    public float crouchSpeed = 2f;
    [SerializeField]
    private float jumpSpeed = 8.0f;
    [SerializeField]
    
    private float antiBumpFactor = .75f;
    [HideInInspector]
    public Vector3 moveDirection = Vector3.zero;
    [HideInInspector]
    public Vector3 contactPoint;
    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public bool playerControl = false;
    [HideInInspector]
    public Vector3 animDir;
    public float gravity = 20.0f;

    public Vector3 animNewestTransform;
    public Vector3 animOldTransform;
    public float groundedSpeed;

    public bool grounded = false;
    public Vector3 jump = Vector3.zero;
    Vector3 jumpedDir;
    public Vector3 respawnPOS;

    private bool forceGravity;
    private float forceTime = 0;
    private float jumpPower;
    UnityEvent onReset = new UnityEvent();
    [HideInInspector]
    public float gravityRef;
    [HideInInspector]
    public float jumpSpeedRef;
    private bool isDead = false;
    private bool exitedJumpPad = false;
    public override void OnEnable()
    {
        base.OnEnable();
        controller = GetComponent<CharacterController>();
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

    }
    private void Start()
    {
        gravityRef = gravity;
        jumpSpeedRef = jumpSpeed;
        respawnPOS = gameObject.transform.position;
    }
    public void AddToReset(UnityAction call)
    {
        onReset.AddListener(call);
    }

    public override void ResetPositionTo(Vector3 resetTo)
    {
        controller.enabled = false;
        StartCoroutine(forcePosition());
        IEnumerator forcePosition()
        {
            //Reset position to 'resetTo'
            transform.position = resetTo;
            //Remove old interpolation
            ForgetPreviousTransforms();
            yield return new WaitForEndOfFrame();
        }
        isDead = false;
        controller.enabled = true;
        onReset.Invoke();
    }

    public override void Update()
    {
        Vector3 newestTransform = m_lastPositions[m_newTransformIndex];
        Vector3 olderTransform = m_lastPositions[OldTransformIndex()];
        animNewestTransform = newestTransform;
        animOldTransform = olderTransform;

        Vector3 adjust = Vector3.Lerp(olderTransform, newestTransform, InterpolationController.InterpolationFactor);
        adjust -= transform.position;

        controller.Move(adjust);

        if (forceTime > 0)
            forceTime -= Time.deltaTime;
        if(isDead == true)
        {
            ResetPositionTo(respawnPOS);
        }

        if(grounded == true && jumpSpeed != jumpSpeedRef && exitedJumpPad == true)
        {
            jumpSpeed = jumpSpeedRef;
            exitedJumpPad = false;
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (forceTime > 0)
        {
            if(forceGravity)
                moveDirection.y -= gravity * Time.deltaTime;
            grounded = (controller.Move(moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
        }
        if(isDead == true)
        {
            ResetPositionTo(respawnPOS);
        }
    }

    public override void LateFixedUpdate()
    {
        base.LateFixedUpdate();
    }

    public void Move(Vector2 input, bool sprint, bool crouching)
    {
        if(forceTime > 0)
            return;

        float speed = (!sprint) ? walkSpeed : runSpeed;


        if (crouching) speed = crouchSpeed;

        if (grounded)
        {
            moveDirection = new Vector3(input.x, -antiBumpFactor, input.y);
            moveDirection = transform.TransformDirection(moveDirection) * speed;
            UpdateJump();
        }
        else
        {
            Vector3 adjust = new Vector3(input.x, 0, input.y);
            adjust = transform.TransformDirection(adjust);
            jumpedDir += adjust * Time.fixedDeltaTime * jumpPower * 2f;
            jumpedDir = Vector3.ClampMagnitude(jumpedDir, jumpPower);
            moveDirection.x = jumpedDir.x;
            moveDirection.z = jumpedDir.z;
        }
        
        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;
        // Move the controller, and set grounded true or false depending on whether we're standing on something
        grounded = (controller.Move(moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
        groundedSpeed = speed;
    }

    public void Move(Vector3 direction, float speed, float appliedGravity)
    {
        if (forceTime > 0)
            return;

        Vector3 move = direction * speed;
        if (appliedGravity > 0)
        {
            moveDirection.x = move.x;
            moveDirection.y -= gravity * Time.deltaTime * appliedGravity;
            moveDirection.z = move.z;
        }
        else
            moveDirection = move;

        UpdateJump();

        grounded = (controller.Move(moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
        groundedSpeed = speed;
    }

    public void Move(Vector3 direction, float speed, float appliedGravity, float setY)
    {
        if (forceTime > 0)
            return;

        Vector3 move = direction * speed;
        if (appliedGravity > 0)
        {
            moveDirection.x = move.x;
            if (setY != 0) moveDirection.y = setY * speed;
            moveDirection.y -= gravity * Time.deltaTime * appliedGravity;
            moveDirection.z = move.z;
        }
        else
            moveDirection = move;

        UpdateJump();

        grounded = (controller.Move(moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
        groundedSpeed = speed;
    }

    public void Jump(Vector3 dir, float mult)
    {
        jump = dir * mult;
    }

    public void UpdateJump()
    {
        if (jump != Vector3.zero)
        {
            Vector3 dir = (jump * jumpSpeed);
            if (dir.x != 0) moveDirection.x = dir.x;
            if (dir.y != 0) moveDirection.y = dir.y;
            if (dir.z != 0) moveDirection.z = dir.z;

            Vector3 move = moveDirection;
            jumpedDir = move; move.y = 0;
            jumpPower = Mathf.Min(move.magnitude, jumpSpeed);
            jumpPower = Mathf.Max(jumpPower, walkSpeed);
        }
        else
            jumpedDir = Vector3.zero;
        jump = Vector3.zero;
    }

    public void ForceMove(Vector3 direction, float speed, float time, bool applyGravity)
    {
        forceTime = time;
        forceGravity = applyGravity;
        moveDirection = direction * speed;
        groundedSpeed = speed;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        contactPoint = hit.point;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PlayerMovement script has entered a trigger");

        if(other.gameObject.CompareTag("Death"))
        {
            Debug.Log("PlayerMovement script has entered a death trigger");
            isDead = true;
        }
        else if(other.gameObject.CompareTag("Jump Pad"))
        {
            exitedJumpPad = false;
            jumpSpeed = other.gameObject.GetComponent<jumpPad>().updateGravityEnter();
        }
        else if(other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPOS = gameObject.transform.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("PlayerMovement script is inside a trigger");

        if (other.gameObject.CompareTag("Death"))
        {
            Debug.Log("PlayerMovement script is inside a death trigger");
            isDead = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Jump Pad"))
        {
            exitedJumpPad = true;
        }
    }

}
