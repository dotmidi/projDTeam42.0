using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Transform destination; // The destination the object will move towards
    public float speed = 5f; // The speed at which the object will move
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction from the current position to the destination
        Vector3 direction = destination.position - transform.position;
        direction.Normalize();

        // Move the object towards the destination
        transform.position += direction * speed * Time.deltaTime;
    }

     void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with a game object that has the "Finish" tag
        if (other.CompareTag("Finish"))
        {
            // Stop the object from moving
            speed = 0f;
        }
    }
}
