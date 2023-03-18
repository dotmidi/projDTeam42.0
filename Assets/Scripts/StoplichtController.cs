using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplichtController : MonoBehaviour
{

    
    public GameObject[] Lichten;
    private bool isChanging = false;
    private int index = 0;
    private int max;



    // Start is called before the first frame update
    void Start()
    {
        max = Lichten.Length;
        Lichten[0].SetActive(true);
        
        
    }

    // Update is called once per frame
    void Update()
    {   
        
           if(Input.GetMouseButtonDown(0))
            {
                index++;
                index = index % max;
                Lichten[index % max].SetActive(true);
                Lichten[(index - 1) % max].SetActive(false);
                print((index - 1) % max);
                isChanging = false;
            }
            
        
        
        
    }

    IEnumerator wait()
    {
        isChanging = true;
        yield return new WaitForSeconds(3);     
    }
}