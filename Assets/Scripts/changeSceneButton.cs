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
        SceneManager.LoadScene(gameChangeScene);
    }
}
