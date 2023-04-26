using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
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
    public TextMeshProUGUI HighScores;
    public int num_scores = 10;


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
        ShowTopScores();
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

    public void ShowTopScores()
    {
        string path = "Assets/scores.txt";
        string line;
        string[] fields;
        string[] playerNames  = new string [num_scores];
        int[] playerScores = new int[num_scores];
        int scores_read = 0;
    
        HighScores.text = "";
        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream && scores_read < num_scores) {
        line = reader.ReadLine();
        fields = line.Split(',');
        HighScores.text += fields[0] + " ; " + fields[1] + "\n";
        scores_read += 1;
    }
  }
}
