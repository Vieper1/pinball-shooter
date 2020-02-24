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
		ScoreText.text = score.ToString();
		LivesText.text = lives.ToString();
    }



	// Game Events
	public void LoseLifePoint()
	{
		lives--;
		if (lives <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
