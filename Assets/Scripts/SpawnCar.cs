using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject car; 
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float x = Random.Range( this.transform.position.x - 10, this.transform.position.x + 10);
            float z = Random.Range( this.transform.position.z - 10, this.transform.position.z + 10);
            Instantiate(car, new Vector3(x,this.transform.position.y,z), Quaternion.identity);
            
        }
    }
}
