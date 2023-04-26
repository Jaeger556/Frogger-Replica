using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Intro : MonoBehaviour
{
    public GameObject scorePanel;
    public GameObject menuCanvas;
    public GameObject settingsPanel;
    public TMP_InputField nameField;
    public Slider spawnSlider;
    public Slider carSlider;
    public TextMeshProUGUI sSliderVal;
    public TextMeshProUGUI cSliderVal;


    public void play()
    {
        PlayerName.playernamestr = nameField.text;

        Car.minSpeed = carSlider.value - 4;
        Car.maxSpeed = carSlider.value;

        CarSpawner.spawnDelay = spawnSlider.value;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Sliders()
    {
        sSliderVal.text = spawnSlider.value.ToString("0.##");
        cSliderVal.text = carSlider.value.ToString("0.##");
    }

    public void scores()
    {
        menuCanvas.SetActive(false);
        scorePanel.SetActive(true);
    }

    public void settings()
    {
        menuCanvas.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void back()
    {
        scorePanel.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void back2()
    {
        settingsPanel.SetActive(false);
        menuCanvas.SetActive(true);
    }
}
