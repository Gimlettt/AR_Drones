using UnityEngine;
using Vuforia;

public class SecondQRCodeTransform : MonoBehaviour
{
    private ImageTargetBehaviour imageTargetBehaviour;
    public CylinderManager cylinderManager; // Reference to the CylinderManager script

    void Start()
    {
        // Find the ImageTargetBehaviour component on the same GameObject
        imageTargetBehaviour = GetComponent<ImageTargetBehaviour>();

        if (imageTargetBehaviour != null)
        {
            Debug.Log("Second QR Code Image Target found");
        }
        else
        {
            Debug.LogError("No Image Target found on this GameObject.");
        }

        // Ensure the cylinderManager reference is set
        if (cylinderManager == null)
        {
            Debug.LogError("CylinderManager is not set.");
        }
    }

    void Update()
    {
        if (imageTargetBehaviour != null)
        {
            // Get the status of the Image Target
            TargetStatus targetStatus = imageTargetBehaviour.TargetStatus;

            // Check if the Image Target is being tracked
            if (targetStatus.Status == Status.TRACKED ||
                targetStatus.Status == Status.EXTENDED_TRACKED)
            {
                // Get the position of the Image Target
                Vector3 secondQRPosition = imageTargetBehaviour.transform.position;

                // Check the position with CylinderManager
                if (cylinderManager != null)
                {
                    cylinderManager.CheckSecondQRCodePosition(secondQRPosition);
                }
            }
        }
        else
        {
            Debug.LogError("ImageTargetBehaviour is null. Ensure the script is attached to the correct GameObject.");
        }
    }
}
