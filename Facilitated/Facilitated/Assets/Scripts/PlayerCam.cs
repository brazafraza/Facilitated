using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

   
    //player orientation
    public Transform orientation;

    //cam rotation
    float xRotation;
    float yRotation;

    private void Start()
    {

        //locking the cursor at play
        Cursor.lockState = CursorLockMode.Locked;
        //turning cursor invisble on play
        Cursor.visible = false;
    }

    private void Update()
    {

        //getting input from mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;


        yRotation += mouseX;

        xRotation -= mouseY;

        //limiting the players cam rotation between -90 and 90
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //applying the rotate to cam and player
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);



      
        
    }


}
