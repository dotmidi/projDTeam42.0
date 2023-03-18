using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplichtController : MonoBehaviour
{

    
    public GameObject[] Lichten;
    public bool wait;
    private int index = 0;
    private int max;

    

    // Start is called before the first frame update
    void Start()
    {
        max = Lichten.Length;
        Lichten[0].SetActive(true);
        wait = true;
        
    }

    // Update is called once per frame
    void Update()
    {   
            
           if(wait == true)
            {
                 StartCoroutine(waiter());
            }
            
    }

   private IEnumerator waiter()
    {
        //Wait for 4 seconds
        wait = false;
        yield return new WaitForSeconds(5);

                index++;
                index = index % max;
                Lichten[index % max].SetActive(true);
                if(index == 0)
                {
                    Lichten[2].SetActive(false);
                    print(index + "in de if");
                }
                else
                {
                    Lichten[(index - 1) % max].SetActive(false);
                    print(index + "in de else");
                }
        wait = true;
    }       
}