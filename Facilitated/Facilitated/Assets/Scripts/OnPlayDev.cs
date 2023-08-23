using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayDev : MonoBehaviour
{
    public GameObject playerMov;
    public GameObject mouseMov;
    //public GameObject mouseMovAgain;
    void Start()
    {
        Cursor.visible = false;
        mouseMov.GetComponent<PlayerCam>().enabled = false;
        playerMov.GetComponent<PlayerMovement>().enabled = false;
        Invoke("MouseMov", 10);
    }

    void MouseMov()
    {
        mouseMov.GetComponent<PlayerCam>().enabled = true;
        playerMov.GetComponent<PlayerMovement>().enabled = true;
    }
    void Update()
    {
        
    }
}
