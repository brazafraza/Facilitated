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
    public bool outOfBed;

    public GameObject canMove;
    public GameObject startText;

    public GameObject marsUp;


    //mars getting up
    public Animator marsAnimator;


    //public GameObject mouseMovAgain;
    void Start()
    {

        Cursor.visible = false;
        mars.SetActive(false);
        canControl = false;
        outOfBed = false;
        startText.SetActive(false);
        marsUp.SetActive(false);

        mouseMov.GetComponent<PlayerCam>().enabled = false;
        playerMov.GetComponent<PlayerMovement>().enabled = false;
        mouseMovCC.GetComponent<PlayerCam>().enabled = false;
        camActive.GetComponent<Camera>().enabled = false;
        
        //invoking each function for character control and mouse control after x time 
        Invoke("MouseMov", 30);
        Invoke("PlayerControlsEnable", 40);
        Invoke("CameraActivate", 30);

    }

    void MouseMov()
    {
        //letting player control mouse movement and destroying cutscene game obj
        mouseMov.GetComponent<PlayerCam>().enabled = true;
        Object.Destroy(marsCS);
    }

    void PlayerControlsEnable()
    {
        //showing press e text
        startText.SetActive(true);
        canControl = true;
        
    }

    void CameraActivate()
    {
        //enabling character camera control and character game object
        camActive.GetComponent<Camera>().enabled = true;
        mars.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && canControl)
        {
            //letting player move and destroying the press e text
            playerMov.GetComponent<PlayerMovement>().enabled = true;
            Object.Destroy(startText);
            
            outOfBed = true;
            mars.SetActive(false);
            marsAnimator.SetTrigger("TrMarsUp");

            //move mars transfomr out of bed to pos of end cutscene mars
            //
        }

        if (outOfBed)
        {
         //playing get out of bed anim
            marsUp.SetActive(true);
            Invoke("DestroyMarsUp", 4);
            //camActive.GetComponent<Camera>().enabled = true;
            outOfBed = false;
        }
    }
    void DestroyMarsUp()
    {
        Object.Destroy(marsUp);
        mars.SetActive(true);
    }
}
