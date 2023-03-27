using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTraffic : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] Points;     
    [SerializeField]private int index = 0;
    [SerializeField]private int maxSize;
    // Start is called before the first frame update
    void Start()
    {
        maxSize = Points.Length;
        agent.SetDestination(Points[index].position);
    }

    // Update is called once per frame
    void Update()
    {

        if(agent.remainingDistance > 1.5)
        {
            agent.SetDestination(Points[index].position);

        }
        else
        {

            index++;
            index %= maxSize;    
            agent.SetDestination(Points[index].position);
           
        }


    
     
            

   
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("box"))
        {
            agent.speed = 0;
        }

    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("box"))
        {
            agent.speed = 3.5f;
        }
    }






 

}
