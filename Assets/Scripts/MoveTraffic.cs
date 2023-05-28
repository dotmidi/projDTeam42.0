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

    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        maxSize = Points.Length;
        agent.SetDestination(Points[index].position);
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
        float maxDistance = 10.0f;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            
            // If the hit object has a speed of 0, stop the agent
            var hitObject = hit.collider.gameObject;
     
            if(hitObject.CompareTag("car") && hitObject != gameObject)
            {
               
                var navMeshAgent = hitObject.GetComponent<NavMeshAgent>();   
                var stopComponent = hitObject.GetComponent<MoveTraffic>();       
            
                if (navMeshAgent != null && (navMeshAgent.speed == 0f || stopComponent.stop || stopComponent.redLight))
                {
                    stop = true;
                    timeSinceLastCar = 0f;
                    
                }
                else 
                {
                    stop = false;               
                }

            }
  

        }
        
        if(stop)
        {
            timeSinceLastCar += Time.deltaTime;
            
        }
        
        if(timeSinceLastCar >= noCarTimeThreshold)
        {
            stop = false;            
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
        else
        {
            agent.speed = 3.5f;
            agent.isStopped = false;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
           
            redLight = false;
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
