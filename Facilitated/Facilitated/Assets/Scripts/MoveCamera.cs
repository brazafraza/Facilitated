using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform cameraPosition;
    
    private void Update()
    {
        //setting transform pos to cam pos from reference
        transform.position = cameraPosition.position; 
    }
}
