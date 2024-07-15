using UnityEngine;
using TMPro;

public class CylinderManager : MonoBehaviour
{
    public GameObject cylinderPrefab; // Reference to the cylinder prefab
    public TextMeshProUGUI coordinateText; // Reference to the coordinate TextMeshPro UI element
    public TextMeshProUGUI popupText; // Reference to the pop-up TextMeshPro UI element
    private GameObject[] cylinders; // Array to hold references to the instantiated cylinders

    void Start()
    {
        // Instantiate cylinders at the specified relative positions
        cylinders = new GameObject[4];
        for (int i = 0; i < cylinders.Length; i++)
        {
            cylinders[i] = Instantiate(cylinderPrefab);
            cylinders[i].SetActive(false); // Start with the cylinders inactive
        }

        // Ensure the text references are set
        if (coordinateText == null)
        {
            Debug.LogError("Coordinate TextMeshPro UI element is not set.");
        }

        if (popupText == null)
        {
            Debug.LogError("Popup TextMeshPro UI element is not set.");
        }
        else
        {
            popupText.text = ""; // Initialize popup text as empty
        }
    }

    public void UpdateCylinderPositions(Vector3 qrPosition, Quaternion qrRotation)
    {
        // Define the relative positions
        Vector3[] relativePositions = new Vector3[]
        {
            new Vector3(0.15f, 0, 0.15f),
            new Vector3(0.15f, 0, -0.15f),
            new Vector3(-0.15f, 0, -0.15f),
            new Vector3(-0.15f, 0, 0.15f)
        };

        // Update the position and rotation of the cylinders
        for (int i = 0; i < cylinders.Length; i++)
        {
            cylinders[i].transform.position = qrPosition + relativePositions[i];
            cylinders[i].transform.rotation = qrRotation;
            cylinders[i].SetActive(true); // Ensure the cylinders are active
        }

        // Update the coordinate text
        if (coordinateText != null)
        {
            coordinateText.text = $"QR Code Position: {qrPosition}\nRotation: {qrRotation}";
        }
    }

    public void HideCylinders()
    {
        // Deactivate the cylinders
        for (int i = 0; i < cylinders.Length; i++)
        {
            if (cylinders[i] != null)
            {
                cylinders[i].SetActive(false);
            }
        }

        // Clear the coordinate text
        if (coordinateText != null)
        {
            coordinateText.text = "QR Code is not tracked.";
        }
    }

    public void CheckSecondQRCodePosition(Vector3 secondQRPosition)
    {
        foreach (GameObject cylinder in cylinders)
        {
            if (Vector3.Distance(cylinder.transform.position, secondQRPosition) < 0.05f) // Adjust the threshold as needed
            {
                popupText.text = "YES!";
                return;
            }
        }
        popupText.text = ""; // Clear the text if no cylinder is close
    }
}
