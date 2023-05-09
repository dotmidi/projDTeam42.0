using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCar : MonoBehaviour
{
    [SerializeField]private int index = StoplichtController.indexpublic;
    public Collider Box;

    
    // Start is called before the first frame update
    void Start()
    {
        Box.isTrigger = true;
        index = StoplichtController.indexpublic;
       

    }

    // Update is called once per frame
    void Update()
    {
        int index = StoplichtController.indexpublic;
        if(index == 2)Box.isTrigger = true; 
        else  Box.isTrigger = false;    


    }
}
