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
        /*if(this.transform.position != Points[index].position)
        {
            agent.SetDestination(Points[index].position);
        }
        else
        {

            index++;
            index %= maxSize;    
            agent.velocity = Vector3.zero;
            agent.nextPosition = transform.position;       
           
        }
        agent.updatePosition = true;*/
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
}
