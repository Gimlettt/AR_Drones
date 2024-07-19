using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Vuforia;
using TMPro;

public class PropSpawn : MonoBehaviour
{
    public TMP_Text canvasText;
    public int droneConfiguration = 8;
    public GameObject propulsionPrefab; // Reference to the cylinder prefab
    public GameObject[] propulsionModules; // Array to hold references to the instantiated cylinders

    //public GameObject[] propulsionObjects; // Array to hold references to the instantiated cylinders
    
 
    private float width = 0.1482f;
    private float height = -0.1009f;
    private float length_pos = 0.3505f;
    private float length_neg = -0.3455f;

    private Vector3[] relativePositions;
    private Vector3[] relativeRotations;

   

    // Start is called before the first frame update
    void Start()
    {
        
         if(droneConfiguration == 4)
        {
                relativePositions = new Vector3[]
            {
                new Vector3(0.2f, height, width),
                new Vector3(0.2f, height, -width),
                new Vector3(-0.2f, height, width),
                new Vector3(-0.2f, height, -width)
                
            };

                relativeRotations = new Vector3[]
            {
                new Vector3(-90, 0, 0),
                new Vector3(-90, 0, 180),
                new Vector3(-90, 0, 0),
                new Vector3(-90, 0, 180)
                
            };

        }  
            if(droneConfiguration == 8)
        {
                relativePositions = new Vector3[]
            {
                new Vector3(0.2f, height, width),
                new Vector3(0.2f, height, -width),
                new Vector3(-0.2f, height, width),
                new Vector3(-0.2f, height, -width),
                new Vector3(0, height, width),
                new Vector3(0, height, -width),
                new Vector3(length_neg, height, 0),
                new Vector3(length_pos, height, 0)
            };

                relativeRotations = new Vector3[]
            {
                new Vector3(-90, 0, 0),
                new Vector3(-90, 0, 180),
                new Vector3(-90, 0, 0),
                new Vector3(-90, 0, 180),
                new Vector3(-90, 0, 0),
                new Vector3(-90, 0, 180),
                new Vector3(-90, -90, 0),
                new Vector3(-90, 90, 0)
            };
        }


        // Instantiate cylinders at the specified relative positions
        propulsionModules = new GameObject[droneConfiguration];
        for (int i = 0; i < propulsionModules.Length; i++)
        {
            propulsionModules[i] = Instantiate(propulsionPrefab, this.transform);
            propulsionModules[i].transform.position = relativePositions[i];
            propulsionModules[i].transform.rotation = Quaternion.Euler(relativeRotations[i]);
            //propulsionModules[i].SetActive(false); 
            
        }

    }

    void Update()
    {
        
        //propulsionModules[i].SetActive(true);
    }
    public void Distance(Vector3 copterPosition)
    {
       float dist = Vector3.Distance(copterPosition, propulsionModules[0].transform.position);

        canvasText.text = "Distance to desired position: " + dist;
    }
}
