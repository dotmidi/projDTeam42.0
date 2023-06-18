using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoplichtenBuild : MonoBehaviour
{
    public GameObject[] Lichten;
    private bool wait;
    [HideInInspector]public int index = 0;
    public int indexpublic = 0;
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
          indexpublic = index;
           if(wait == true)
            {
                if(index == 1)
                {
                    StartCoroutine(waiter(2));
                }
                else
                {
                    StartCoroutine(waiter(5));
                }
            }
    }
     private IEnumerator waiter(int Time)
     {
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
