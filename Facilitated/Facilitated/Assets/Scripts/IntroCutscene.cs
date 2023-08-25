using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{
    public GameObject introCanvas;

    void Start()
    {
        Invoke("CanvasCancel", 15);
        

    }

    void CanvasCancel()
    {
        introCanvas.SetActive(false);
    }

}


