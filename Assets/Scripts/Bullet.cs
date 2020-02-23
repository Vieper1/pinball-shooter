using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float lifeTime = 9999.0f;

	void Start()
	{
		lifeTime = GameConfig.BULLET_LIFETIME;
	}

	void Update()
    {
		lifeTime -= Time.deltaTime;
		if (lifeTime < 0)
		{
			Destroy(gameObject);
		}
    }
}
