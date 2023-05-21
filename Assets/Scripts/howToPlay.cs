using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howToPlay : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public GameObject pauseMenuPanel;    public void howToPlayButton()
    {
        // if the howToPlayPanel is not active, make it active and vice versa. Also hide pauseMenuPanel
        if (!howToPlayPanel.activeSelf)
        {
            howToPlayPanel.SetActive(true);
            pauseMenuPanel.SetActive(false);
        }
        else
        {
            howToPlayPanel.SetActive(false);
            pauseMenuPanel.SetActive(true);
        }
    }
}
