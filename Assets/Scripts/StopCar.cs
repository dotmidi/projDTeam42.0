using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCar : MonoBehaviour
{

    public int index;
    public StoplichtController stoplichtController;
    public Collider Box;

    
    // Start is called before the first frame update
    void Start()
    {
        //Box.isTrigger = true;
        //index = StoplichtController.indexpublic;
        index = stoplichtController.indexpublic;

       

    }

    // Update is called once per frame
    void Update()
    {
        index = stoplichtController.indexpublic;
        // if(index == 2)Box.isTrigger = true; 
        // else  Box.isTrigger = false;    


    }
}
