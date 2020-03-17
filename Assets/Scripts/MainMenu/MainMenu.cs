using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[Header("References")]
	public Text HighScoreValueText;
	public Button TutorialButton;

    void Start()
    {
		HighScoreValueText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
	}

	public void PlayNow()
	{
		SceneManager.LoadSceneAsync("Level1");
	}

	public void ShowTutorial()
	{
		TutorialButton.gameObject.SetActive(true);
	}

	public void HideTutorial()
	{
		TutorialButton.gameObject.SetActive(false);
	}
}
