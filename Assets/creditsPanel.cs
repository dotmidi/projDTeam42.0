using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsPanel : MonoBehaviour
{
    public GameObject creditsPanelPanel;
    public GameObject pauseMenuPanel;
    public void creditsPanelButton()
    {
        // if the creditsPanelPanel is not active, make it active and vice versa. Also hide pauseMenuPanel
        if (!creditsPanelPanel.activeSelf)
        {
            creditsPanelPanel.SetActive(true);
            pauseMenuPanel.SetActive(false);
        }
        else
        {
            creditsPanelPanel.SetActive(false);
            pauseMenuPanel.SetActive(true);
        }
    }
}
