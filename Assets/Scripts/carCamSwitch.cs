using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCamSwitch : MonoBehaviour
{
    public Camera FirstPerson;
    public Camera ThirdPerson;
    public Camera FreeCam;
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
            ThirdPerson.enabled = false;
            FirstPerson.enabled = false;
            FreeCam.enabled = !FreeCam.enabled;
            if(FreeCam.enabled == false) 
            {
                ThirdPerson.enabled = true;
            }
        }
        
    }
}
