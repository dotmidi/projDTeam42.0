using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeleteObject : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    public GameObject Crosshair;
    public static bool DestroyMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(carCamSwitch.freeFlyCam)
        {
            if(Input.GetKeyDown("x"))
            {
                DestroyMode = !DestroyMode;
                BuildingSystem.buildModeOn = !DestroyMode;
                if(DestroyMode)
                {
                    Crosshair.SetActive(true);
                }
                else
                {
                    Crosshair.SetActive(false);
                }
            }
        }
        if(!carCamSwitch.freeFlyCam)
        {
            Crosshair.SetActive(false);
        }

        if(DestroyMode && Input.GetMouseButtonDown(0))
        {
            
            RaycastHit buildPosHit;
            if(Physics.Raycast(playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out buildPosHit, 100))
            {   
                if(buildPosHit.transform.gameObject.name == "Prefab-Block")
                {
                    Destroy(buildPosHit.transform.gameObject);
                        
                }
                 
            }
                
        }
    }
}


