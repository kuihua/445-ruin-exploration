using UnityEngine;

public class RaycastColorChanger : MonoBehaviour
{
    // [SerializeField]
    // TestDeleteMe referenceToScript;

    // [SerializeField]
    // GameObject leftController;



    public float maxDistance = 10f; // Max distance for the raycast
    public Color highlightColor = Color.red; // The color to change when the object is looked at
    public float colorChangeSpeed = 0.5f; // Speed of color transition

    private Renderer lastHitRenderer = null; // Keep track of the last hit object's renderer
    private Color originalColor; // Store the original color of the object

    void Update()
    {
        // Create a ray from the camera's position in the forward direction
        // Vector3 rotationOfLeftHand = leftController.transform.rotation.eulerAngles;
        //Vector3 rotationOfLeftHand = leftController.transform.forward;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Check if the ray hits an object within max distance
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            Renderer hitRenderer = hit.transform.GetComponent<Renderer>();

            // If the object has a Renderer component
            if (hitRenderer != null)
            {
                // If it's a new object we're looking at, store its original color
                if (hitRenderer != lastHitRenderer)
                {
                    if (lastHitRenderer != null)
                    {
                        // Gradually reset the color of the previous object
                        // lastHitRenderer.material.color = Color.Lerp(lastHitRenderer.material.color, originalColor, colorChangeSpeed * Time.deltaTime);
                        lastHitRenderer.material.color = originalColor;
                    }

                    originalColor = hitRenderer.material.color;
                    lastHitRenderer = hitRenderer;
                }

                // Gradually change the object's color to the highlight color
                // hitRenderer.material.color = Color.Lerp(hitRenderer.material.color, highlightColor, 1);
                hitRenderer.material.color = Color.Lerp(hitRenderer.material.color, highlightColor, colorChangeSpeed * Time.deltaTime);
                // hitRenderer.material.color = highlightColor;
            }
        }
        else
        {
            // If nothing is hit and we previously looked at an object, reset its color
            if (lastHitRenderer != null)
            {
                Debug.Log("not looking");
                // lastHitRenderer.material.color = Color.Lerp(lastHitRenderer.material.color, originalColor, colorChangeSpeed * Time.deltaTime);
                lastHitRenderer.material.color = originalColor;

                // If the object's color is back to the original, clear the reference
                if (Vector4.Distance(lastHitRenderer.material.color, originalColor) < 0.01f)
                {
                    lastHitRenderer = null;
                }
            }
        }
    }
}
