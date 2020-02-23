using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("References")]
    public GameObject prefab_Projectile;
	public GameObject GunSprite;

	[Header("Config")]
	public float ProjectileForceMultiplier = 1.0f;
	public float ProjectileScaleMultiplier = 1.0f;
	public float InactiveDelay = 1.0f;
	public float SpawnOffset = 1.0f;
    


    // Drag
    private Vector2 dragStart;
    private bool isDragging;

	// Inactivity
	private float inactiveTime = -1.0f;
	private SpriteRenderer gunSprite;

    void Start()
    {
		gunSprite = GunSprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
		if (inactiveTime > 0)
		{
			inactiveTime -= Time.deltaTime;
		}
		else
		{
			SetGunActiveIndicator(true);	// Optimmize
		}


		if (IsSelfClicked() && inactiveTime < 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				isDragging = true;
				dragStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
		}

		if (isDragging)
		{
			if (Input.GetMouseButton(0))
			{
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.rotation = Quaternion.FromToRotation(Vector3.up, mousePosition - dragStart);
			}

			if (Input.GetMouseButtonUp(0) && isDragging)
			{
				isDragging = false;
				SetGunActiveIndicator(false);
				ShootProjectile();
			}
		}
	}

	bool IsSelfClicked()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
		if (hit.transform == transform)
		{
			return true;
		}
		return false;
	}

	void ShootProjectile()
	{
		GameObject projectile = Instantiate(prefab_Projectile);
		projectile.transform.rotation = transform.rotation;
		projectile.transform.position = transform.position + transform.up * SpawnOffset;
		projectile.transform.localScale = projectile.transform.localScale * ProjectileScaleMultiplier;
		Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
		rb2d.AddForce(projectile.transform.up * ProjectileForceMultiplier, ForceMode2D.Impulse);
		inactiveTime = InactiveDelay;
	}

	void SetGunActiveIndicator(bool value)
	{
		Color color = gunSprite.color;
		color.a = value ? 1f : 0.6f;
		gunSprite.color = color;
	}
}
