using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnPlayDev : MonoBehaviour
{
    public GameObject playerMov;
    public GameObject camActive;
    public GameObject mouseMov;
    public GameObject mars;
   
    public GameObject mouseMovCC;
    public GameObject marsCS;

    public bool canControl;

    public GameObject canMove

    //public GameObject mouseMovAgain;
    void Start()
    {
        Cursor.visible = false;
        mars.SetActive(false);
        mouseMov.GetComponent<PlayerCam>().enabled = false;
        playerMov.GetComponent<PlayerMovement>().enabled = false;
        mouseMovCC.GetComponent<PlayerCam>().enabled = false;
        camActive.GetComponent<Camera>().enabled = false;
        canControl = false;
        // playerMovCC.GetComponent<PlayerMovement>().enabled = false;
        Invoke("MouseMov", 30);
        Invoke("PlayerControlsEnable", 40);
        Invoke("CameraActivate", 30);


        
    }

    void MouseMov()
    {
        mouseMov.GetComponent<PlayerCam>().enabled = true;
       
        // playerMov.GetComponent<PlayerMovement>().enabled = true;
        Object.Destroy(marsCS);
    }

    void PlayerControlsEnable()
    {
        //playerMov.GetComponent<PlayerMovement>().enabled = true;
        canControl = true;
        
    }

    void CameraActivate()
    {
        camActive.GetComponent<Camera>().enabled = true;
        mars.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && canControl)
        {
            playerMov.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
