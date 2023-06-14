using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTraffic : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] Points;

    [SerializeField]
    private int index = 0;

    [SerializeField]
    private int maxSize;
    public bool canbedelete = false; //only for testing
    public bool stop = false;
    public bool redLight = false;
    public float timeSinceLastCar = 0f;
    public const float noCarTimeThreshold = 3f;
    public float timeSinceTrafficLight = 0f;
    public const float norTafficLightTimeThreshold = 3f;
    public float distanceToCarInFront = 0f;
    public float desiredDistance = 4f;
    public bool tooclose = false;

    

    public GameObject parent;

    public GameObject[] Cars;

    // Start is called before the first frame update
    void Start()
    {
        maxSize = Points.Length;
        agent.SetDestination(Points[index].position);
        int randomindexCar = Random.Range(0, Cars.Length);

        for(int i = 0; i < Cars.Length; i++)    
        {
            Cars[i].SetActive(false);
        }
        Cars[randomindexCar].SetActive(true);

    

        MeshFilter meshFilter = Cars[randomindexCar].GetComponent<MeshFilter>();
        MeshCollider meshCollider = GetComponent<MeshCollider>();

        meshCollider.sharedMesh = meshFilter.sharedMesh;





    }

    // Update is called once per frame
    void Update()
    {

        if (canbedelete && index == maxSize - 1 && agent.remainingDistance <= 1.5)
        {
            Destroy(parent);
            return;
            
        }
        // Create a raycast in the direction of the agent's movement


        RaycastHit hit;
        float maxDistance = 15.0f;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {

            
            // If the hit object has a speed of 0, stop the agent
            var hitObject = hit.collider.gameObject;
     
            if(hitObject.CompareTag("car") && hitObject != gameObject)
            {
                distanceToCarInFront = Vector3.Distance(transform.position, hitObject.transform.position);
                print("hit car");
                var navMeshAgent = hitObject.GetComponent<NavMeshAgent>();   
                var stopComponent = hitObject.GetComponent<MoveTraffic>();       
            
                if (navMeshAgent != null && (navMeshAgent.speed == 0f || stopComponent.stop || stopComponent.redLight))
                {
                    stop = true;
                    timeSinceLastCar = 0f;                    
                }
                else 
                {
                    
                    if (distanceToCarInFront < desiredDistance)
                    
                    {
                            tooclose = true;
                    }
                    else
                    {
                        tooclose = false;
                        
                        stop = false; 
                    }
                    
                                  
                }

            }
        
  

        }
        
        if(stop || tooclose)
        {
            timeSinceLastCar += Time.deltaTime;
            
        }        
    
        
        if(timeSinceLastCar >= noCarTimeThreshold)
        {
            stop = false; 
            distanceToCarInFront = -1;  
            tooclose = false;
            timeSinceLastCar = 0f;         
        }
        if(redLight)
        {
            timeSinceTrafficLight += Time.deltaTime;
        }
        if(timeSinceTrafficLight >= norTafficLightTimeThreshold)
        {
            CheckForTrafficLight();            
        }


        if (agent.remainingDistance > 1.5)
        {
            agent.SetDestination(Points[index].position);

        }
        else
        {

            index++;
            index %= maxSize;
            agent.SetDestination(Points[index].position);
        }



        if (redLight || stop)
        {
            agent.speed = 0;
            agent.isStopped = true;
        }
        else if(tooclose)
        {
            float ratio = distanceToCarInFront / desiredDistance;
            float minSpeed = 1.5f; // Set the minimum speed (1.0 units per second)
            float maxSpeed = 3.5f; // Set the maximum speed (3.5 units per second)

            // Interpolate between the minimum and maximum speed based on the ratio
            agent.speed = Mathf.Lerp(minSpeed, maxSpeed, 1 - ratio);
        }
        else
        {
            agent.speed = 3.5f;
            agent.isStopped = false;
        }
    }

    void CheckForTrafficLight()
    {
        RaycastHit hit;
        float maxDistance = 10.0f;
        timeSinceTrafficLight = 0f;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            if (hit.collider.gameObject.CompareTag("traffic_light"))
            {
               
                return; // A traffic light with the "traffic_light" tag was found in front of the car
            }
        }
    
    redLight = false;
    return; // No traffic light found in front of the car
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {           
            redLight = false;
            timeSinceTrafficLight = 0f;
        }
        if(other.gameObject.CompareTag("Radius"))
        {
            Destroy(parent);
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            StopCar stopCarScript = other.gameObject.GetComponentInParent<StopCar>();

            if (stopCarScript != null && stopCarScript.index != 2)
            {
              
                redLight = false;
            }
            else
            {
                
                redLight = true;
            }
        }

    }





    



}
