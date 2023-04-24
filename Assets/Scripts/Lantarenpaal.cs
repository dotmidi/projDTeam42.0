using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantarenpaal : MonoBehaviour
{


    [SerializeField]

    private GameObject pointlight;

    [SerializeField]

    private GameObject spotlight;

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
                pointlight.SetActive(true);
                spotlight.SetActive(true);
            }
            else
            {
                pointlight.SetActive(false);
                spotlight.SetActive(false);
            }
        }
}
