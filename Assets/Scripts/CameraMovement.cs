using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    private float xRotation = 20f;
    private float yRotation = 0f; 
    private Vector3 StartLocation = new Vector3(20f,0f,0f);
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(StartLocation);      
    
    }

    // Update is called once per frame
    void Update()
    {      
         // Check if the left mouse button is being held down
         if(Input.GetMouseButton(0))
        {
            // Calculate the amount of rotation based on the movement of the mouse
            float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Rotate the camera around the x-axis based on the vertical movement of the mouse
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -45f, 45f); // Clamp the rotation to prevent camera flipping
            
            // Rotate the camera around the y-axis based on the horizontal movement of the mouse
            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, -35f, 35f);

            // Apply the rotation to the camera
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
        if(Input.GetMouseButtonUp(0))// Check if the left mouse button has been released
        {
            // Reset the camera to its starting position
             transform.localRotation = Quaternion.Euler(StartLocation);    
             yRotation = 0f;  
             xRotation = 20f;
        }

    }



}
