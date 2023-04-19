using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_Car : MonoBehaviour
{
    public bool spawn_Test = false;
    public GameObject[] Car_Type;
    // Start is called before the first frame update
    void Update()
    {
        if(spawn_Test)
        {
            Spawn_car();
            spawn_Test = false;
        }
    }
  
    public void Spawn_car()
    {
        Instantiate(Car_Type[0], new Vector3(this.transform.position.x,Car_Type[0].transform.position.y,this.transform.position.z), transform.rotation);
    }
}
