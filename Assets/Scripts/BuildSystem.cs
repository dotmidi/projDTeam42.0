using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour {

    [SerializeField]
    private BlockType[] allBlockTypes;

    [HideInInspector]
    public Dictionary<int, Block> allBlocks = new Dictionary<int, Block>();

    private void Awake()
    {
        for (int i = 0; i < allBlockTypes.Length; i++)
        {
            Block newBlock = new Block(i, "Prefab");
            allBlocks[i] = newBlock;
        }
    }

}

public class Block
{
    public int blockID;
    public string blockName;
    public Material blockMaterial;

    public Block (int id, string name) 
    {
        blockID = id;
        blockName = name;
    }
}

[Serializable]
public struct BlockType
{
    public string blockName;
}
