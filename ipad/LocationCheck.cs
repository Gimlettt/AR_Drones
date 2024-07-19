using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;

public class LocationCheck : MonoBehaviour
{
    private ImageTargetBehaviour imageTargetBehaviour;
    //public PropSpawn propSpawn; // Reference to the propSpawn script
    public GameObject propulsionObject;
    //public Propspawn propSpawn;
    public TMP_Text canvasText;
    public PropSpawn propSpawn;


    // Start is called before the first frame update
      void Start()
    {
        // Find the ImageTargetBehaviour component on the same GameObject
        //imageTargetBehaviour = GetComponent<ImageTargetBehaviour>();
        
    }

    void Update()
    {
       Vector3 copterPosition = propulsionObject.transform.position;
       propSpawn.Distance(copterPosition);
       //float dist = Vector3.Distance(propulsionObject.transform.position, propSpawn.propulsionModules[0].transform.position);
            //print("Distance to other: " + dist);

            //canvasText.text = "Distance to other: " + dist;
    }
}
