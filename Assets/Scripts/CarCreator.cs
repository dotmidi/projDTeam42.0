using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCreator : MonoBehaviour
{
    // Start is called before the first frame update
 
    public List<GameObject> spawners;
    public float timeBetween = 1.5f;
    public float time;
    void Start()
    {

        time = timeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        int randomSpawner = Random.Range(0, spawners.Count);
        
        if(time <= 0 && spawners.Count > 0)
        {
            spawners[randomSpawner].GetComponent<spawner_Car>().Spawn_car();
            time = timeBetween;

        }
        else
        {
            time -= Time.deltaTime ;
        }
    }

    private void OnTriggerEnter(Collider other) {
       
        if(other.gameObject.tag == "Spawner")
        {           
            spawners.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Spawner")
        {        
            spawners.Remove(other.gameObject);
        }
    }
}
