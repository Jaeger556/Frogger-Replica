using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    public static bool isPaused = false;

    public void resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    void pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
