using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantarenpaal : MonoBehaviour
{


    [SerializeField]

    private GameObject pointlight;

    [SerializeField]

    private GameObject spotlight;

    public GameObject Lantarenpalen;

    [SerializeField]
    private GameObject Sun;

    private bool isNight = false;
   
        // Start is called before the first frame update
        void Start()
        {
                
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.N) &&  !isNight)
            {
                isNight = !isNight;
                Sun.transform.Rotate(0, 90, 0);
            }
            else if(Input.GetKeyDown(KeyCode.N) && isNight)
            {
                isNight = !isNight;
                Sun.transform.Rotate(0, -90, 0);
            }
            if(isNight)
            {
                foreach(Transform child in Lantarenpalen.transform)
                        {
                            foreach(Transform child2 in child)
                            {
                                if(child2.gameObject.name == "Point Light")
                                {
                                    child2.gameObject.SetActive(true);
                                }
                                if(child2.gameObject.name == "Spot Light")
                                {
                                    child2.gameObject.SetActive(true);
                                }
                            }
                        }
            }
            else
            {
                foreach(Transform child in Lantarenpalen.transform)
                        {
                            foreach(Transform child2 in child)
                            {
                                if(child2.gameObject.name == "Point Light")
                                {
                                    child2.gameObject.SetActive(false);
                                }
                                if(child2.gameObject.name == "Spot Light")
                                {
                                    child2.gameObject.SetActive(false);
                                }
                            }
                        }
            }
        }
}
