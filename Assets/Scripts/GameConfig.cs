using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
	public static float BULLET_LIFETIME = 1.0f;
	public static float BULLET_FORCE_MULTIPLIER = 1.0f;
	public static float SLOWMOTION_FACTOR = 0.05f;
	public static float RESPAWN_DELAY = 1.0f;

	// Setters
	public float Bullet_LifeTime = 1.0f;
	public float Bullet_ForceMultiplier = 1.0f;
	public float Slowmotion_Factor = 1.0f;
	public float Respawn_Delay = 1.0f;

	void Start()
	{
		BULLET_LIFETIME = Bullet_LifeTime;
		BULLET_FORCE_MULTIPLIER = Bullet_ForceMultiplier;
		SLOWMOTION_FACTOR = Slowmotion_Factor;
		RESPAWN_DELAY = Respawn_Delay;
	}
}
