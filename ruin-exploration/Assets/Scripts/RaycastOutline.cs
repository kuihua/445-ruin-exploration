using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RaycastOutline : MonoBehaviour
{

    [SerializeField] XRRayInteractor rayInteractor;
    private float maxRayDistance;
    private Renderer lastHitRenderer = null; // Keep track of the last hit object's renderer
    Renderer[] lastOtherRenderers = null;

    private float hideOutlineScale = 0f;
    private float showOutlineScale = 0.015f;

    // [SerializeField] private Color showColour = new Color (232,234, 63);
    // [SerializeField] private Color hideColour = Color.clear;


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
            //testing
            Renderer[] otherRenderers = new Renderer[0];
            // Renderer childRenderer
            // if(hitRenderer != null) {
            //     Debug.Log(hitRenderer.gameObject.name);
            // }

            // if (hitRenderer != null && string.Compare(raycastHit.collider.name, "skull") == 0 ) {
            if (hitRenderer != null && raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("interactables") ) {
                Debug.Log(raycastHit.collider.name);
                if(hitRenderer.gameObject.GetComponent<MultipleMeshes>() != null) {
                    otherRenderers = hitRenderer.gameObject.GetComponent<MultipleMeshes>().otherRenderers;
                }

                if (hitRenderer != lastHitRenderer) {
                    if (lastHitRenderer != null) {
                        // hide outline of previous object
                        lastHitRenderer.materials[1].SetFloat("_Outline_Thickness", hideOutlineScale);
                        // lastHitRenderer.materials[1].SetColor("_Color", hideColour);
                        if(lastOtherRenderers != null) {
                            foreach(Renderer r in lastOtherRenderers) {
                                r.materials[1].SetFloat("_Outline_Thickness", hideOutlineScale);
                            }
                        }
                    }
                    // Debug.Log("saved");
                    lastHitRenderer = hitRenderer;
                    lastOtherRenderers = otherRenderers;
                }
                // show outline
                // Debug.Log(hitRenderer.materials[1].name);
                hitRenderer.materials[1].SetFloat("_Outline_Thickness", showOutlineScale);  
                // hitRenderer.materials[1].SetColor("_Color", showColour);
                foreach(Renderer r in otherRenderers) {
                    r.materials[1].SetFloat("_Outline_Thickness", showOutlineScale);
                }
            }
            else {
           // If nothing is hit and we previously looked at an object, reset its color
            if (lastHitRenderer != null) {
                // Debug.Log("not looking " + lastHitRenderer.name);
                // hide outline of previous object
                lastHitRenderer.materials[1].SetFloat("_Outline_Thickness", hideOutlineScale);
                // lastHitRenderer.materials[1].SetColor("_Color", showColour);
                if(lastOtherRenderers != null) {
                    foreach(Renderer r in lastOtherRenderers) {
                        r.materials[1].SetFloat("_Outline_Thickness", hideOutlineScale);
                    }
                }

                // If the object's color is back to the original, clear the reference
                if (lastHitRenderer.materials[1].GetFloat("_Outline_Thickness") == hideOutlineScale)
                {
                    lastHitRenderer = null;
                    lastOtherRenderers = null;
                }

                // if (lastHitRenderer.materials[1].color == showColour)
                // {
                //     lastHitRenderer = null;
                // }
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
