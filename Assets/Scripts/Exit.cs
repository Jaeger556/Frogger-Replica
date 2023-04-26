using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject exitCanvas;
    public GameObject scorePanel;


    public void scores()
    {
        exitCanvas.SetActive(false);
        scorePanel.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void back()
    {
        scorePanel.SetActive(false);
        exitCanvas.SetActive(true);
    }
}
