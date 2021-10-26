using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Shooting : MonoBehaviour
{
    PlayerInput playerInput;
    [HideInInspector]
    public Camera cam;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private AnimController animController;

    private Quaternion projectileRotation;

    public Transform sourcePoint;
    public float projectileSpeed = 30f;

    private Vector3 destination;

    void Start() {
        cam = Camera.main;
        playerInput = GetComponent<PlayerInput>();
    }

    void Update() {
        /*
        if (playerInput.shoot) {
            InstantiateProjectile(sourcePoint);
        }
        */

    }

    public void ShootProjectile() {
        Ray raycast = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)) {
            destination = hit.point;
            //projectileRotation = Quaternion.LookRotation(transform.position, hit.point);
        }
        Debug.Log("Destination 1: " + destination.ToString());

        InstantiateProjectile(sourcePoint);
    }

    public void InstantiateProjectile(Transform firePoint) {
        var projectileObject = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObject.GetComponent<Rigidbody>().velocity = cam.transform.forward * projectileSpeed;
        projectileObject.transform.LookAt(destination);
        Debug.Log("Destination 2: " + destination.ToString());
    }
}
