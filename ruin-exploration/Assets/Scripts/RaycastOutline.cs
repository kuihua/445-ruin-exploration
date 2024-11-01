using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RaycastOutline : MonoBehaviour
{

    [SerializeField] XRRayInteractor rayInteractor;
    private float maxRayDistance;
    private Renderer lastHitRenderer = null; // Keep track of the last hit object's renderer

    private float hideOutlineScale = 0.1f;
    private float showOutlineScale = 1.15f;

    [SerializeField] private Color showColour = new Color (166,197, 238);
    [SerializeField] private Color hideColour = Color.clear;


    // Start is called before the first frame update
    void Start()
    {
        // set raycast distance the same as the ray length
        maxRayDistance = rayInteractor.maxRaycastDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit raycastHit;

        // Check if the ray hits an object within max distance
        if (Physics.Raycast(ray, out raycastHit, maxRayDistance)) {
            Renderer hitRenderer = raycastHit.transform.GetComponent<Renderer>();

            // if (hitRenderer != null && string.Compare(raycastHit.collider.name, "skull") == 0 ) {
            if (hitRenderer != null && raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("interactables") ) {
                // Debug.Log(raycastHit.collider.name);

                if (hitRenderer != lastHitRenderer) {
                    if (lastHitRenderer != null) {
                        // hide outline of previous object
                        // lastHitRenderer.materials[1].SetFloat("_Scale", hideOutlineScale);
                        lastHitRenderer.materials[1].SetColor("_Color", hideColour);
                    }
                    Debug.Log("saved");
                    lastHitRenderer = hitRenderer;
                }
                // show outline
                // Debug.Log(hitRenderer.materials[1].name);
                // hitRenderer.materials[1].SetFloat("_Scale", showOutlineScale);  
                hitRenderer.materials[1].SetColor("_Color", showColour);
            }
            else {
           // If nothing is hit and we previously looked at an object, reset its color
            if (lastHitRenderer != null) {
                // Debug.Log("not looking " + lastHitRenderer.name);
                // hide outline of previous object
                // lastHitRenderer.materials[1].SetFloat("_Scale", hideOutlineScale);
                lastHitRenderer.materials[1].SetColor("_Color", showColour);

                // If the object's color is back to the original, clear the reference
                // if (lastHitRenderer.materials[1].GetFloat("_Scale") == hideOutlineScale)
                // {
                //     lastHitRenderer = null;
                // }

                if (lastHitRenderer.materials[1].color == showColour)
                {
                    lastHitRenderer = null;
                }
            }
        }

        } 
        // else {
        //    // If nothing is hit and we previously looked at an object, reset its color
        //     if (lastHitRenderer != null) {
        //         // Debug.Log("not looking " + lastHitRenderer.name);
        //         // hide outline of previous object
        //         lastHitRenderer.materials[1].SetFloat("_Scale", hideOutlineScale);
        //         // lastHitRenderer.materials[1].SetColor("_Color", showColour);

        //         // If the object's color is back to the original, clear the reference
        //         if (lastHitRenderer.materials[1].GetFloat("_Scale") == hideOutlineScale)
        //         {
        //             lastHitRenderer = null;
        //         }
        //     }
        // }

    }
}
