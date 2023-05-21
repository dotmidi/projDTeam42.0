using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneButton : MonoBehaviour
{
    // Build number of the scene to load when the button is pressed
    public int gameChangeScene;

    public void changeScene()
    {
        // if current scene isnt 1, load scene 1, if it is, load scene 0
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            SceneManager.LoadScene(gameChangeScene);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }
}
