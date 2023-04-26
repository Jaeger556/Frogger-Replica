using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static string playerName;
    public GameObject scorePanel;
    private static int score;
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] int maxHighscores = 10;

    private List<Highscore> highscores;

    
    void Start()
    {
        playerName = "";

        highscores = new List<Highscore>();
    
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Intro":
                LoadHighscores();
                UpdateHighscoreText();
                Debug.Log("Loading high scores: " + highscores.Count);
                break;
            case "exit":
                //UpdateHighscoreText();
                break;
            case "level01":
                LoadHighscores();
                UpdateHighscoreText();
                DontDestroyOnLoad(gameObject);
                break;
        }
    }

    void LoadHighscores()
    {
        Debug.Log("Loading High Scores.");
        string highscoreData = PlayerPrefs.GetString("highscores", "");
        Debug.Log(highscoreData);
        if (highscoreData.Length > 0)
        {
            highscores = JsonUtility.FromJson<List<Highscore>>(highscoreData);
        }
        else
        {
            highscores = new List<Highscore>();
        }
    }

    void SaveHighscores()
    {
        highscores.Sort();
        highscores.Reverse();
        highscores = highscores.GetRange(0, Mathf.Min(highscores.Count, maxHighscores));
        string highscoreData = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscores", highscoreData);
        PlayerPrefs.Save();
        Debug.Log("Saved high scores: " + highscores.Count);
    }

    void AddHighscore(int score)
    {
        Highscore highscore = new Highscore(playerName, score);
        highscores.Add(highscore);
        SaveHighscores();
        UpdateHighscoreText();
    }

    void UpdateHighscoreText()
    {
        string highscoreString = "";
        for (int i = 0; i < highscores.Count; i++)
        {
            highscoreString += $"{i + 1}. {highscores[i].name} - {highscores[i].score}\n";
        }
        highscoreText.text = highscoreString;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    void OnDisable()
    {
        SaveHighscores();
    }

    private class Highscore : System.IComparable<Highscore>
    {
        public string name;
        public int score;

        public Highscore(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public int CompareTo(Highscore other)
        {
            return score.CompareTo(other.score);
        }
    }
}
