using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
	public float speed;
	public float damage;
	public Color friendlyColor;
	public Color enemyColor;
	public GameObject player;
	public Vector3 predictedPlayerPos;
	public bool isFriendly;

	private bool hitSomething = false;
	private bool initialized = false;
	
    public void Initialize() {
		if (isFriendly) {
			// Get the mouse position in world coordinates, on the z=0 plane
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mouseWorldPos.z = 0; 
			SetRotationOnPos(mouseWorldPos);

			gameObject.GetComponent<SpriteRenderer>().color = friendlyColor;
		}
		else {
			SetRotationOnPos(predictedPlayerPos);
			gameObject.GetComponent<SpriteRenderer>().color = enemyColor;
		}
		
		gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
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
					else {
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

	void SetRotationOnPos(Vector3 pos) {
		// Rotate at mouseWorldPos by setting the right direction (front of the sprite) to the direction between transform.position and mouseWorldPos
		transform.right = pos - transform.position;
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
