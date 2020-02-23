using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
	public static float BULLET_LIFETIME = 1.0f;

	// Setters
	public float Bullet_LifeTime = 1.0f;

	void Start()
	{
		BULLET_LIFETIME = Bullet_LifeTime;
	}
}
