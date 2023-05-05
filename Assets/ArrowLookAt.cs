using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLookAt : MonoBehaviour
{
    public Transform target;
    public Transform arrow;
    private bool isTriggered = false;

    // Start is called before the first frame update
    void Start() {
        arrow.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update() { 
        if (isTriggered == true)
        {
            arrow.GetComponent<Renderer>().enabled = true;
            //arrow.LookAt(target);
        } else
        {
            //arrow.transform.LookAt(new Vector3(target.position.x, arrow.position.y, target.position.z));
            //arrow.GetComponent<Renderer>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Start")
        {
            // show the arrow renderer
            Debug.Log("Start");
            arrow.GetComponent<Renderer>().enabled = true;
            isTriggered = true;
        }

        if (other.gameObject.name == "Finish")
        {
            // hide the arrow renderer
            isTriggered = false;
            arrow.GetComponent<Renderer>().enabled = false;
        }
    }
}
