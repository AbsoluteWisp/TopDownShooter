using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
	public float speed;
	public float damage;
	public Color friendlyColor;
	public Color enemyColor;
	public GameObject player;
	public bool isFriendly;

	private bool hitSomething = false;
	private bool initialized = false;
	
    public void Initialize() {
		if (isFriendly) {
			SetRotationOnMouse();
			gameObject.GetComponent<SpriteRenderer>().color = friendlyColor;
			gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
		}
		else {
			gameObject.GetComponent<SpriteRenderer>().color = enemyColor;
		}
		
		initialized = true;
    }

	void Update() {
		if (gameObject.GetComponent<SpriteRenderer>().isVisible == false) {
			Destroy();
		}
	}

    public void OnCollisionEnter2D(Collision2D collision) {
		GameObject hitObject = collision.gameObject;

		if (initialized) {
			switch (hitObject.tag) {
				case "Enemy":
					if (isFriendly) {
						hitObject.GetComponent<EnemyBehaviour>().OnHit(damage);
						hitSomething = true;
					}
					break;
				case "Player":
					if (!isFriendly) {
						hitObject.GetComponent<PlayerHealth>().Hurt(damage);
						hitSomething = true;
					}
					break;
				case "Projectile":
					if (hitObject.GetComponent<ProjectileBehaviour>().isFriendly != isFriendly) {
						hitObject.GetComponent<ProjectileBehaviour>().OnHit();
						hitSomething = true;
					}
					break;
				case "Obstacle":
					hitSomething = true;
					break;
			}

			// If anything described by the above tags was hit, destroy this projectile
			if (hitSomething) {
				Destroy();
			}
		}
    }

	void SetRotationOnMouse() {
		// Get the mouse position in world coordinates, on the z=0 plane
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPos.z = 0; 

		// Rotate at mouseWorldPos by setting the right direction (front of the sprite) to the direction between transform.position and mouseWorldPos
		transform.right = mouseWorldPos - transform.position;
	}

	public void OnHit() {
		Destroy();
	}

	void Destroy() {
		if (isFriendly) {
			player.GetComponent<PlayerController>().ammo += 1;
		}

		Destroy(gameObject);
	}
}
