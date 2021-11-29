using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Pickup))]
public class OutlineScript : MonoBehaviour
{
    RaycastHit HitInfo;
    private GameObject item;

    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;
    private Renderer outlineRenderer;
    [SerializeField] public GameObject pickupText;



    void Start() {
        item = this.gameObject;
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
    }

    Renderer CreateOutline (Material outlineMat, float scaleFactor, Color color) {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Renderer rend = outlineObject.GetComponent<Renderer>();
        rend.material = outlineMat;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_ScaleFactor", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        outlineObject.GetComponent<OutlineScript>().enabled = false;
        outlineObject.GetComponent<Collider>().enabled = false;
        
        rend.enabled = false;

        return rend;
    }

    private void Update() {
        
        if(this.GetComponent<Pickup>().CanPickUp()) { //if the player is in range to pick up the item draw the outline and print the "press e to pick up" text
            outlineRenderer.enabled = true;
            outlineRenderer.gameObject.transform.position = this.gameObject.transform.position;
            outlineRenderer.gameObject.transform.rotation = this.gameObject.transform.rotation;
            pickupText.SetActive(true);
        }
        else {
            outlineRenderer.enabled = false;
            pickupText.SetActive(false);

        }

    }

}
