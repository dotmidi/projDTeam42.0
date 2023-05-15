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
            Destroy(gameObject);
            return;
        }

        // Create a raycast in the direction of the agent's movement


        RaycastHit hit;
        float maxDistance = 4.0f;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            // If the hit object has a speed of 0, stop the agent
            var hitObject = hit.collider.gameObject;
            var navMeshAgent = hitObject.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null && navMeshAgent.speed == 0)
            {
                stop = true;
            }
            else
            {
                stop = false;
            }
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
        }
        else
        {
            agent.speed = 3.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            agent.speed = 0;
            redLight = true;
        }
        print(agent.speed);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            agent.speed = 3.5f;
            redLight = false;
        }
    }
}
