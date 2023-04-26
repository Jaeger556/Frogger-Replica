using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Exit : MonoBehaviour
{
    public GameObject exitCanvas;
    public GameObject scorePanel;
    public TextMeshProUGUI HighScores;
    public int num_scores = 5;


    public void scores()
    {
        ShowTopScores();
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
