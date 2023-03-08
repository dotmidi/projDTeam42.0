using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCamSwitch : MonoBehaviour
{
    public Camera FirstPerson;
    public Camera ThirdPerson;
    // Start is called before the first frame update
    void Start()
    {
        ThirdPerson.enabled = true;
        FirstPerson.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            FirstPerson.enabled = !FirstPerson.enabled;
            ThirdPerson.enabled = !ThirdPerson.enabled;
        }
    }
}
