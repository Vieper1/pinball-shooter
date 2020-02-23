using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
	public static float BULLET_LIFETIME = 1.0f;
	public static float SLOWMOTION_FACTOR = 0.05f;

	// Setters
	public float Bullet_LifeTime = 1.0f;
	public float Slowmotion_Factor = 1.0f;

	void Start()
	{
		BULLET_LIFETIME = Bullet_LifeTime;
		SLOWMOTION_FACTOR = Slowmotion_Factor;
	}
}
