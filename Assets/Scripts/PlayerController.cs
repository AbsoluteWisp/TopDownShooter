using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Global data
	public KeyCode keyShoot;
	public KeyCode keyMoveUp;
	public KeyCode keyMoveDown;
	public KeyCode keyMoveRight;
	public KeyCode keyMoveLeft;
	public GameObject projectilePrefab;
	public float speed;
	public Transform projectileParent;

	// Session data (global data that changes throughout the game session)	
	public int health;
	public int ammo;

	// Private data
	private Rigidbody2D localRB;

	void Start() {
		localRB = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update() {
		// Player inputs for this frame
		float frameVerticalMoveSpeed = 0f;
		float frameHorizontalMoveSpeed = 0f;

		if (Input.GetKey(keyMoveUp)) {
			frameVerticalMoveSpeed += speed;
		}
		else if (Input.GetKey(keyMoveDown)) {
			frameVerticalMoveSpeed -= speed;
		}
		if (Input.GetKey(keyMoveRight)) {
			frameHorizontalMoveSpeed += speed;
		}
		else if (Input.GetKey(keyMoveLeft)) {
			frameHorizontalMoveSpeed -= speed;
		}

		// Apply frame velocity changes
		localRB.velocity = new Vector2(frameHorizontalMoveSpeed, frameVerticalMoveSpeed);
		
		// Update rotation
		SetRotationOnMouse(); 

		// Shoot if keyShoot was clicked this frame
		if (Input.GetKeyDown(keyShoot)) {
			Shoot();
		}
	}

	void Shoot() {
		if (ammo > 0) {
			ammo -= 1;
			GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, projectileParent);
			Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
			projectile.GetComponent<ProjectileBehaviour>().player = gameObject;
			projectile.GetComponent<ProjectileBehaviour>().isFriendly = true;
			projectile.GetComponent<ProjectileBehaviour>().Initialize();
		}
	}

	public void OnHit() {
		health -= 1;
	}
	void SetRotationOnMouse() {
		// Get the mouse position in world coordinates, on the z=0 plane
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPos.z = 0; 

		// Rotate at mouseWorldPos by setting the right direction (front of the player sprite) to the direction between transform.position and mouseWorldPos
		transform.right = mouseWorldPos - transform.position;
	}
}
