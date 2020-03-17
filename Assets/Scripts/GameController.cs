using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController instance;

	[Header("References")]
	public Text ScoreText;
	public Text LivesText;

	private int lives;
	private int score;

    void Start()
    {
		if (instance != this)
			instance = this;
		InitGame();
    }

    void Update()
    {
		if (ScoreText)
			ScoreText.text = score.ToString();
		if (LivesText)
			LivesText.text = lives.ToString();
    }



	// Game Events
	public void LoseLifePoint()
	{
		lives--;
		if (lives <= 0)
		{
			int highscore = PlayerPrefs.GetInt("highscore", 0);
			if (score > highscore)
			{
				PlayerPrefs.SetInt("highscore", score);
			}
			SceneManager.LoadScene("MainMenu");
		}
	}

	public void AddScorePoints(int points)
	{
		score += points;
	}


	// Utility
	void InitGame()
	{
		lives = 3;
		score = 0;
	}
}
