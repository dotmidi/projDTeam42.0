using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;


    private GameObject[] AllPlaced;
    public static bool buildModeOn = false;
    private bool canBuild = false;

    [SerializeField]
    public GameObject KeuzeScherm;
    public Component[] ChilderColor;
    private BuildSystem bSys;

    private bool Rotate;

    [SerializeField]
    private LayerMask buildableSurfacesLayer;

    private Vector3 buildPos;

    private GameObject currentTemplateBlock;

    [SerializeField]
    private GameObject[] blockTemplatePrefab;
    [SerializeField]
    private GameObject[] blockPrefab;

    [SerializeField]
    private Material templateMaterial;

    private int blockSelectCounter = 0;

    private void Start()
    {
        bSys = GetComponent<BuildSystem>();
    }

    private void Update()
    {
        
        
        if (Input.GetKeyDown("e"))
        {
            if(carCamSwitch.freeFlyCam)
            {
                buildModeOn = !buildModeOn;
                DeleteObject.DestroyMode = !buildModeOn;
            }
            if (buildModeOn)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if(buildModeOn)
            {
                KeuzeScherm.SetActive(true);
              
            }
            else
            {
                KeuzeScherm.SetActive(false);
            }
        }

        
       

        if (buildModeOn)
        {

            if (Input.GetKeyDown("1"))
            {
                blockSelectCounter = 0;
                print(blockSelectCounter);
                //if (blockSelectCounter >= bSys.allBlocks.Count) blockSelectCounter = 0;
                Destroy(currentTemplateBlock.gameObject);
            }
            else if(Input.GetKeyDown("2"))
            {
                blockSelectCounter = 1;
                print(blockSelectCounter);
               // if (blockSelectCounter <= bSys.allBlocks.Count) blockSelectCounter = 0;
                Destroy(currentTemplateBlock.gameObject);
            }

            else if(Input.GetKeyDown("3"))
            {
                blockSelectCounter = 2;
                print(blockSelectCounter);
                //if (blockSelectCounter <= bSys.allBlocks.Count) blockSelectCounter = 0;
                Destroy(currentTemplateBlock.gameObject);
            }

            else if(Input.GetKeyDown("4"))
            {
                blockSelectCounter = 3;
                print(blockSelectCounter);
                //if (blockSelectCounter <= bSys.allBlocks.Count) blockSelectCounter = 0;
                Destroy(currentTemplateBlock.gameObject);
            }


            RaycastHit buildPosHit;
            if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                if(Input.GetKey(KeyCode.RightArrow))
                {
                    RotateBlock360(100f);
                }
                else if(Input.GetKey(KeyCode.LeftArrow))
                {
                    RotateBlock360(-100f);
                }
                
            }

            if(Input.GetMouseButtonDown(1))
            {
                RotateBlock();
            }
             if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                print("test");
                if(Input.GetKey(KeyCode.DownArrow))
                {
                    MoveBlockUpDown(10f);
                }
                else if(Input.GetKey(KeyCode.UpArrow))
                {
                    MoveBlockUpDown(10f);
                }
                
            }

            if(Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                IncreaseSize();
            }
             if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                DecreaseSize();
            }

           
        if (Physics.Raycast(playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out buildPosHit, 100, buildableSurfacesLayer))
{
    Vector3 point = buildPosHit.point;
    float groundHeight = point.y;

    // Use a second raycast to determine the distance between the ground and the center of the object
    RaycastHit centerHit;
    if (Physics.Raycast(new Vector3(point.x, point.y + blockPrefab[blockSelectCounter].transform.lossyScale.y / 2, point.z), Vector3.down, out centerHit, 1.0f, buildableSurfacesLayer))
    {
        float objectHeight = blockPrefab[blockSelectCounter].transform.lossyScale.y;
        float thickness = centerHit.distance - objectHeight / 2;
        groundHeight -= thickness;
    }

    buildPos = new Vector3(Mathf.Round(point.x), groundHeight, Mathf.Round(point.z));
    canBuild = true;
}
   
            
            else
            {
                Destroy(currentTemplateBlock.gameObject);
                canBuild = false;
            }
        }
        

        if (!buildModeOn && currentTemplateBlock != null)
        {
            Destroy(currentTemplateBlock.gameObject);
            canBuild = false;
        }

        if (canBuild && currentTemplateBlock == null)
        {
            currentTemplateBlock = Instantiate(blockTemplatePrefab[blockSelectCounter], buildPos, Quaternion.identity);
            currentTemplateBlock.GetComponent<MeshRenderer>().material = templateMaterial;

    
                        
        }

        if (canBuild && currentTemplateBlock != null)
        {
            currentTemplateBlock.transform.position = buildPos;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceBlock();
            }
        }
    }

    private void PlaceBlock()
    {
        GameObject newBlock = Instantiate(blockPrefab[blockSelectCounter], buildPos,currentTemplateBlock.transform.rotation);
        newBlock.transform.localScale = currentTemplateBlock.transform.localScale;

        Block tempBlock = bSys.allBlocks[blockSelectCounter];
        newBlock.name = tempBlock.blockName + "-Block";
    }

    private void RotateBlock360(float rotateAmount)
    {
        
        currentTemplateBlock.transform.Rotate(0, rotateAmount * Time.deltaTime, 0);
        
    }

    private void MoveBlockUpDown(float moveAmount)
    {
        currentTemplateBlock.transform.localPosition += new Vector3(0, 1000f, 0);
    }


    private void IncreaseSize()
    {
        currentTemplateBlock.transform.localScale += new Vector3(0.05f, 0.05f,0.05f);
        
    }

     private void DecreaseSize()
    {
        currentTemplateBlock.transform.localScale += new Vector3(-0.05f, -0.05f,-0.05f);
        
    }

     private void RotateBlock()
    {
        
        currentTemplateBlock.transform.Rotate(0, 90, 0);
        
    }
   
}