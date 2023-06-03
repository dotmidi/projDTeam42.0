using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMaterial : MonoBehaviour
{
    public Material[] materials;
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        int randomIndexmaterial = Random.Range(0, materials.Length);
        Renderer bodyRenderer = body.GetComponent<Renderer>();
        bodyRenderer.material = materials[randomIndexmaterial];
    }


}
