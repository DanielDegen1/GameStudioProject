﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{

    private PlayerInput playerInput;

    Vector2 _mouseAbsolute;
    Vector2 _smoothMouse;

    public GameObject characterBody;

    [SerializeField]
    private PlayerController playerController;

    private CinemachineVirtualCamera vcam;

    private float fov = 60f;
    [SerializeField]
    private float normalfov = 60f;
    [SerializeField]
    private float sprintfov = 95f;
    [SerializeField]
    private float fovSmoothFactor = 10f;

    [SerializeField]
    private Vector2 clampInDegrees = new Vector2(360, 180);
    [SerializeField]
    private Vector2 sensitivity = new Vector2(2, 2);
    [SerializeField]
    private Vector2 smoothing = new Vector2(3, 3);
    [SerializeField]
    private Vector2 targetDirection;
    [SerializeField]
    private Vector2 targetCharacterDirection;

    void Start()
    {
        vcam = this.GetComponent<CinemachineVirtualCamera>();

        playerInput = PlayerInput.Instance;
        // Set target direction to the camera's initial orientation.
        targetDirection = transform.localRotation.eulerAngles;

        // Set target direction for the character body to its inital state.
        if (characterBody)
            targetCharacterDirection = characterBody.transform.localRotation.eulerAngles;
    }

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // Allow the script to clamp based on a desired target value.
        var targetOrientation = Quaternion.Euler(targetDirection);
        var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);

        // Get raw mouse input for a cleaner reading on more sensitive mice.
        var mouseDelta = playerInput.GetMouseDelta();
        // Scale input against the sensitivity setting and multiply that against the smoothing value.
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

        // Interpolate mouse movement over time to apply smoothing delta.
        _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
        _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);

        // Find the absolute mouse movement value from point zero.
        _mouseAbsolute += _smoothMouse;
        // Clamp and apply the local x value first, so as not to be affected by world transforms.
        if (clampInDegrees.x < 360)
            _mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);

        // Then clamp and apply the global y value.
        if (clampInDegrees.y < 360)
            _mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);

        transform.localRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right) * targetOrientation;

        // If there's a character body that acts as a parent to the camera
        if (characterBody)
        {
            var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, Vector3.up);
            characterBody.transform.localRotation = yRotation * targetCharacterOrientation;
        }
        else
        {
            var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
            transform.localRotation *= yRotation;
        }

        //Control FOV based on sprinting status
        if (playerController.status == Status.sprinting)
        {
            if (fov < sprintfov)
            {
                fov = Mathf.Lerp(fov, sprintfov, fovSmoothFactor * Time.deltaTime);
            }
        }
        else
        {
            if (fov > normalfov)
            {
                fov = Mathf.Lerp(fov, normalfov, fovSmoothFactor * Time.deltaTime);

            }
        }
        vcam.m_Lens.FieldOfView = fov;

    }

    public void AddRecoil(Vector3 recoil, float time)
    {
        float recoilElapsed = 0;
        StartCoroutine(recoilIncrease());
        IEnumerator recoilIncrease()
        {
            while (recoilElapsed < time)
            {
                recoilElapsed += Time.deltaTime;
                _mouseAbsolute += (Vector2)(recoil * Time.deltaTime / time);
                yield return null;
            }
        }
    }
}
