using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		switch (collision.transform.tag)
		{
			case "Bumper":
				GameController.instance.AddScorePoints(GameConfig.SCORE_BUMPER);
				break;
			case "Bullet":
				GameController.instance.AddScorePoints(GameConfig.SCORE_BULLET);
				break;
			default:
				GameController.instance.AddScorePoints(GameConfig.SCORE_WALL);
				break;
		}
	}
}
