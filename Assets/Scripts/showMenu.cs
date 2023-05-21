using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showMenu : MonoBehaviour
{
    // find menu object with the name pauseMenu
    public GameObject menu;
    public GameObject howToPlayMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the escape key is pressed set the state to active, if it is already active set it to inactive
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf == false)
            {
                menu.SetActive(true);
                howToPlayMenu.SetActive(false);
                // enable the cursor
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                menu.SetActive(false);
                howToPlayMenu.SetActive(false);
                // disable the cursor
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
