using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCar : MonoBehaviour
{
    private int index = StoplichtController.index;
    public Collider Box;

    
    // Start is called before the first frame update
    void Start()
    {
        Box.isTrigger = true;
       

    }

    // Update is called once per frame
    void Update()
    {
        int index = StoplichtController.index;
        if(index == 2)Box.isTrigger = true; 
        else  Box.isTrigger = false;    


    }
}
