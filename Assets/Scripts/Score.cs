using UnityEngine;
using UnityEngine.UI;
using System;


[Serializable]
public class Score : MonoBehaviour {

	public static int CurrentScore = 0;

	public Text scoreText;

	void Start ()
	{
		scoreText.text = "Score: " + CurrentScore.ToString();
	}

}
