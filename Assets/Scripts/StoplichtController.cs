using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplichtController : MonoBehaviour
{

    
    public GameObject[] Lichten;
    private bool wait;
    [HideInInspector]public int index = 0;
    public int indexpublic = 0;
    private int max;

    

    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {   
          
            
    }
    public void Rood()
    {
        Lichten[2].SetActive(true);
        Lichten[0].SetActive(false);
        Lichten[1].SetActive(false);
        indexpublic = 2;
    }


    public void Oranje()

    { 
         Lichten[2].SetActive(false);
        Lichten[0].SetActive(false);
        Lichten[1].SetActive(true);
        indexpublic = 1;
    }
      public void Groen()
    {
        Lichten[2].SetActive(false);
        Lichten[0].SetActive(true);
        Lichten[1].SetActive(false);
        indexpublic = 0;
        print("groen");
    }
 
     

}