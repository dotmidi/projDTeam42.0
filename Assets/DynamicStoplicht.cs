using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicStoplicht : MonoBehaviour
{

    public StoplichtController stoplichtController;

    public GameObject[] dynamicStoplicht;
    // Start is called before the first frame update
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        int index = dynamicStoplicht[1].GetComponent<StoplichtController>().indexpublic; // Accessing public variable indexpublic
        print(index);
    }
}
