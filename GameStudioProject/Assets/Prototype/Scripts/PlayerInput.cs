using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerInput : MonoBehaviour
{
    private static PlayerInput _instance;

    public static PlayerInput Instance{
        get {
            return _instance;
        }
    }

    private PlayerControls playerControls;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
        playerControls = new PlayerControls();
        Cursor.visible = false;
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    public Vector2 input
    {
        get
        {
            return playerControls.PlayerMovement.Movement.ReadValue<Vector2>();
            /*
            Vector2 i = Vector2.zero;
            i.x = Input.GetAxis("Horizontal");
            i.y = Input.GetAxis("Vertical");
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i;
            */
        }
    }

    public Vector2 down
    {
        get { return _down; }
    }

    public Vector2 GetMouseDelta() {
        return playerControls.PlayerMovement.Look.ReadValue<Vector2>();
    }

    public Vector2 raw
    {
        get
        {
            return playerControls.PlayerMovement.Movement.ReadValue<Vector2>();
            /*
            Vector2 i = Vector2.zero;
            i.x = Input.GetAxisRaw("Horizontal");
            i.y = Input.GetAxisRaw("Vertical");
            i *= (i.x != 0.0f && i.y != 0.0f) ? .7071f : 1.0f;
            return i;
            */
        }
    }

    public float elevate
    {
        get
        {
            return playerControls.PlayerMovement.Elevate.ReadValue<float>();
            //return Input.GetAxis("Elevate");
        }
    }

    public bool run
    {
        get {
            if (playerControls.PlayerMovement.Sprint.ReadValue<float>() > 0) {
                return true;
            }
            else {
                return false;
            }
        }
    }

    public bool crouch
    {
        get { return playerControls.PlayerMovement.Crouch.triggered;}
    }

    public bool crouching
    {
        get { return playerControls.PlayerMovement.Crouching.triggered;}
    }

    public bool interact {
        get{
            return playerControls.PlayerMovement.Interact.triggered;
        }
    }

    public bool Throw {
        get{
            return playerControls.PlayerMovement.Throw.triggered;
        }
    }

    public bool shoot {
        get {
            return playerControls.PlayerMovement.Shoot.triggered;
        }
    }
    public bool Stasis
    {
        get
        {
            return playerControls.PlayerMovement.Stasis.triggered;
        }
    }

    public bool Pause {
        get {
            return playerControls.PlayerMovement.Pause.triggered;
        }
    }


    /*
    public bool throw {
        get {
            return playerControls.PlayerMovement.Throw.triggered;
        }
    }
    */

    /*
    public KeyCode interactKey
    { 
        get { return KeyCode.E; }
    }
    */

    /*
    public bool reload
    {
        get { return Input.GetKeyDown(KeyCode.R); }
    }

    public bool aim
    {
        get { return Input.GetMouseButtonDown(1); }
    }

    public bool aiming
    {
        get { return Input.GetMouseButton(1); }
    }

    public bool shooting
    {
        get { return Input.GetMouseButton(0); }
    }

    public float mouseScroll
    { 
        get { return Input.GetAxisRaw("Mouse ScrollWheel"); }
    }
    */

    private Vector2 previous;
    private Vector2 _down;

    private int jumpTimer;
    private bool jump;

    void Start()
    {
        jumpTimer = -1;
    }

    void Update()
    {
        _down = Vector2.zero;
        if (raw.x != previous.x)
        {
            previous.x = raw.x;
            if (previous.x != 0)
                _down.x = previous.x;
        }
        if (raw.y != previous.y)
        {
            previous.y = raw.y;
            if (previous.y != 0)
                _down.y = previous.y;
        }
    }

    public void FixedUpdate()
    {
        if (!(playerControls.PlayerMovement.Jump.ReadValue<float>() > 0))
        {
            jump = false;
            jumpTimer++;
        }
        else if (jumpTimer > 0) {
            Debug.Log("Jump");
            jump = true;
        }
    }

    public bool Jump()
    {
        return jump;
    }

    public void ResetJump()
    {
        jumpTimer = -1;
    }
}
