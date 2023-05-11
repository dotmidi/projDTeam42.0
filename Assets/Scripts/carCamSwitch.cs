using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCamSwitch : MonoBehaviour
{
    public Camera FirstPerson;
    public Camera ThirdPerson;
    public Camera FreeCam;
    public static bool freeFlyCam;
    public static bool carCam = true;
    // Start is called before the first frame update
    void Start()
    {
        ThirdPerson.enabled = true;
        FirstPerson.enabled = false;
        FreeCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && FreeCam.enabled == false)
        {
            FirstPerson.enabled = !FirstPerson.enabled;
            ThirdPerson.enabled = !ThirdPerson.enabled;
            FreeCam.enabled = false;
            
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(Input.GetKeyDown(KeyCode.F) && freeFlyCam)
            {
                print("test");
                BuildingSystem.buildModeOn = false;
                DeleteObject.DestroyMode = false;
            }   
            ThirdPerson.enabled = false;
            FirstPerson.enabled = false;
            FreeCam.enabled = !FreeCam.enabled;
            freeFlyCam = !freeFlyCam;
            carCam = !carCam;
            if(FreeCam.enabled == false) 
            {
                ThirdPerson.enabled = true;
            }
           
        }

        
        
    }
}
