using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicStoplicht : MonoBehaviour
{

    public StoplichtController stoplichtController;

    [SerializeField]
    public GameObject[] dynamicStoplicht;
    public bool wait = true;
    public int index = 0;
    public bool active = true;
    // Start is called before the first frame update
    
    void Start()
    {
        dynamicStoplicht[0].GetComponent<StoplichtController>().Groen();
        for(int i = 1; i < dynamicStoplicht.Length; i++)
        {
            dynamicStoplicht[i].GetComponent<StoplichtController>().Rood();
        }
    }

    // Update is called once per frame
    
        void Update()
        {   
            if(active == true)
            {
                Switch();
            }
        }

        private void Switch()
        {
            active = false;
            if(index > dynamicStoplicht.Length -1)
            {
                index = 0;
             }
            if(wait == true)
            {       
                    StartCoroutine(waiter(5));
                    dynamicStoplicht[index].GetComponent<StoplichtController>().Rood();
                    index++;
                    if(index > dynamicStoplicht.Length -1)
                    {
                        index = 0;
                    }
                    dynamicStoplicht[index].GetComponent<StoplichtController>().Groen();
                    print(index);

            }
            active = true;
        }
        private IEnumerator waiter(int Time)
        {
            wait = false;
            yield return new WaitForSeconds(Time);
            print("waited");
            wait = true;
        }      
}
