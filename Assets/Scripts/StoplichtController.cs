using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplichtController : MonoBehaviour
{

    
    public GameObject[] Lichten;
    public int timetoskip;
    public bool wait;
    private int index = 0;
    private int max;

    

    // Start is called before the first frame update
    void Start()
    {
        max = Lichten.Length;
        Lichten[0].SetActive(true);
        wait = true;
        timetoskip = 5;
        
    }

    // Update is called once per frame
    void Update()
    {   
            
           if(wait == true)
            {
                if(index == 1)
                {
                    StartCoroutine(waiter(2));
                }
                else
                {
                    StartCoroutine(waiter(10));
                }
            }
            
    }

   private IEnumerator waiter(int Time)
    {
        //Wait for 5 seconds
        wait = false;
        yield return new WaitForSeconds(Time);

                index++;
                index = index % max;
                Lichten[index % max].SetActive(true);
                if(index == 0)
                {
                    Lichten[2].SetActive(false);
                }
                else
                {
                    Lichten[(index - 1) % max].SetActive(false);
                }
        wait = true;
    }      
     

}