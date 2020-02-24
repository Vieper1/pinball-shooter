using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBox : MonoBehaviour
{
	[Header("Config")]
	public GameObject Ball;

	private Vector3 resetPosition;
	private Rigidbody2D ballRb2d;

    void Start()
    {
		resetPosition = Ball.transform.position;
		ballRb2d = Ball.GetComponent<Rigidbody2D>();
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Ball"))
		{
			StartCoroutine(RespawnBallInSeconds());
		}
	}

	IEnumerator RespawnBallInSeconds()
	{
		Ball.transform.position = new Vector3(9999f, 9999f);
		yield return new WaitForSeconds(GameConfig.RESPAWN_DELAY);
		Ball.transform.position = resetPosition;
		ballRb2d.velocity = Vector3.zero;
	}
}
