using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float lifeTime = 9999.0f;
	private bool scheduledForDeletion;

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

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!scheduledForDeletion)
			StartCoroutine(DestroyAfterSeconds(0.1f));
	}

	IEnumerator DestroyAfterSeconds(float seconds)
	{
		scheduledForDeletion = true;
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}
}
