using UnityEngine;
using Vuforia;

public class ImageTargetTransform : MonoBehaviour
{
    private ImageTargetBehaviour imageTargetBehaviour;

    void Start()
    {
        // Find the ImageTargetBehaviour component on the same GameObject
        imageTargetBehaviour = GetComponent&lt;ImageTargetBehaviour&gt;();

        if (imageTargetBehaviour != null)
        {
            Debug.Log("Image Target found");
        }
        else
        {
            Debug.LogError("No Image Target found on this GameObject.");
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
                Vector3 position = imageTargetBehaviour.transform.position;

                // Optionally, get the rotation of the Image Target
                Quaternion rotation = imageTargetBehaviour.transform.rotation;

                // Log the position and rotation
                Debug.Log($"Image Target Position: {position}");
                Debug.Log($"Image Target Rotation: {rotation}");
            }
            else
            {
                Debug.Log("Image Target is not tracked.");
            }
        }
        else
        {
            Debug.LogError("ImageTargetBehaviour is null. Ensure the script is attached to the correct GameObject.");
        }
    }
}