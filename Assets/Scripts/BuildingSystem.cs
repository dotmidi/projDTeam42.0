using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;

    private bool buildModeOn = false;
    private bool canBuild = false;

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
            buildModeOn = !buildModeOn;

            if (buildModeOn)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
            
        }

        if (Input.GetKeyDown("t"))
        {
            blockSelectCounter++;
            print(blockSelectCounter);
            if (blockSelectCounter >= bSys.allBlocks.Count) blockSelectCounter = 0;
            Destroy(currentTemplateBlock.gameObject);

        }
       

        if (buildModeOn)
        {
            RaycastHit buildPosHit;
            if(Input.GetKeyDown("y"))
            {
                RotateBlock();
            }
            if (Physics.Raycast(playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out buildPosHit, 100, buildableSurfacesLayer) && !Rotate)
            {
                Vector3 point = buildPosHit.point;
                buildPos = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y) + (blockPrefab[blockSelectCounter].transform.lossyScale.y / 2), Mathf.Round(point.z));
                canBuild = true;
            }
            else if (Physics.Raycast(playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out buildPosHit, 100, buildableSurfacesLayer) && Rotate)
            {
                Vector3 point = buildPosHit.point;
                buildPos = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y / 4) + (blockPrefab[blockSelectCounter].transform.lossyScale.y / 2), Mathf.Round(point.z));
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

            ChilderColor  = GetComponentsInChildren<HingeJoint>();

             foreach (var i in ChilderColor)
             {
                i.GetComponent<MeshRenderer>().material = templateMaterial;
             }
                        
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
        GameObject newBlock = Instantiate(blockPrefab[blockSelectCounter], buildPos,currentTemplateBlock.transform.rotation );
        

        Block tempBlock = bSys.allBlocks[blockSelectCounter];
        newBlock.name = tempBlock.blockName + "-Block";
    }

    private void RotateBlock()
    {
        currentTemplateBlock.transform.Rotate(0, 90, 0);
    }

   
}