using UnityEngine;
using TMPro;
using Vuforia;

// Useless comment

public class ImageTargetTransform : MonoBehaviour
{
    private ImageTargetBehaviour imageTargetBehaviour;
    public TextMeshProUGUI coordinateTextMeshPro; // Reference to the TextMeshPro UI element
    public CylinderManager cylinderManager; // Reference to the CylinderManager script

    void Start()
    {
        // Find the ImageTargetBehaviour component on the same GameObject
        imageTargetBehaviour = GetComponent<ImageTargetBehaviour>();

        if (imageTargetBehaviour != null)
        {
            Debug.Log("Image Target found");
        }
        else
        {
            Debug.LogError("No Image Target found on this GameObject.");
        }

        // Ensure the coordinateTextMeshPro reference is set
        if (coordinateTextMeshPro == null)
        {
            Debug.LogError("Coordinate TextMeshPro UI element is not set.");
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

            // Log the current status
            Debug.Log($"Target Status: {targetStatus.Status}");

            // Check if the Image Target is being tracked
            if (targetStatus.Status == Status.TRACKED ||
                targetStatus.Status == Status.EXTENDED_TRACKED)
            {
                // Get the position of the Image Target
                Vector3 qrPosition = imageTargetBehaviour.transform.position;
                Quaternion qrRotation = imageTargetBehaviour.transform.rotation;

                // Log the position and rotation
                Debug.Log($"Image Target Position: {qrPosition}");
                Debug.Log($"Image Target Rotation: {qrRotation}");

                // Update the coordinateTextMeshPro with the position
                if (coordinateTextMeshPro != null)
                {
                    coordinateTextMeshPro.text = $"Position: {qrPosition}";
                }

                // Update the cylinders' positions
                if (cylinderManager != null)
                {
                    cylinderManager.UpdateCylinderPositions(qrPosition, qrRotation);
                }
            }
            else
            {
                Debug.Log("Image Target is not tracked.");
                if (coordinateTextMeshPro != null)
                {
                    coordinateTextMeshPro.text = "Image Target is not tracked.";
                }

                // Hide the cylinders if the QR code is not tracked
                if (cylinderManager != null)
                {
                    cylinderManager.HideCylinders();
                }
            }
        }
        else
        {
            Debug.LogError("ImageTargetBehaviour is null. Ensure the script is attached to the correct GameObject.");
        }
    }
}
