using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnCar : MonoBehaviour
{
    public GameObject car; 
    public float timeBetween = 1.5f;
    public float time;
  
   
    // Start is called before the first frame update
    void Start()
    {
     
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            float x = Random.Range( this.transform.position.x - 10, this.transform.position.x + 10) + 5;
            float z = Random.Range( this.transform.position.z - 10, this.transform.position.z + 10) + 5;
            Instantiate(car, new Vector3(x,this.transform.position.y,z), Quaternion.identity);
           
            Transform point = car.transform.Find("point");
            
            float xpoint = Random.Range(car.transform.position.x - 10, car.transform.position.x + 10) + 10;
            float zpoint = Random.Range(car.transform.position.z - 10, car.transform.position.z + 10) + 10;
            point.transform.position = new Vector3(xpoint,car.transform.position.y,zpoint);

             time = timeBetween;
            
        }
        else
        {
            time -= Time.deltaTime ;
        }
        

    }
    
}
