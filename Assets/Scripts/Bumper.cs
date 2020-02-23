using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
	[Header("Config")]
	public float ForceMultiplier = 1.0f;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Ball"))
		{
			Rigidbody2D rb2d = collision.transform.GetComponent<Rigidbody2D>();
			List<ContactPoint2D> contactPoints = new List<ContactPoint2D>();
			Vector2 netNormal = Vector2.zero;


			collision.GetContacts(contactPoints);
			foreach (ContactPoint2D point in contactPoints)
			{
				netNormal += point.normal;
			}
			netNormal.Normalize();


			rb2d.AddForce(netNormal * -1.0f * ForceMultiplier, ForceMode2D.Impulse);
		}
	}
}
