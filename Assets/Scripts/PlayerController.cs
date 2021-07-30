using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Global data
	public KeyCode keyShoot;
	public KeyCode keySprint;
	public KeyCode keyMoveUp;
	public KeyCode keyMoveDown;
	public KeyCode keyMoveRight;
	public KeyCode keyMoveLeft;
	public GameObject projectilePrefab;
	public Transform projectileParent;
	public UIUpdater UI;

	// Session data, potentially variable, think of it as "stats"
	public float speed;
	public float stamina;
	public float maxStamina;
	public float sprintSpeedFactor;
	public float staminaRecoveryFactor;
	public float attackDamage;
	public float projectileSpeed;
	public int ammo;
	public int maxAmmo;

	// Private data
	private PlayerHealth localHealth;
	private Rigidbody2D localRB;

	void Start() {
		localRB = gameObject.GetComponent<Rigidbody2D>();
		localHealth = gameObject.GetComponent<PlayerHealth>();
		ammo = maxAmmo;
		stamina = maxStamina;
	}

	void Update() {
		// Player inputs for this frame
		float frameVerticalMoveSpeed = 0f;
		float frameHorizontalMoveSpeed = 0f;
		float sprintModifier = 1f;

		// Use up stamina while sprinting at a 1:1 rate to seconds sprinting
		if (Input.GetKey(keySprint) && stamina > 0) {
			sprintModifier = sprintSpeedFactor;
			stamina -= Time.deltaTime;
		}
		// Recover stamina while not sprinting at 1:staminaRecoveryFactor rate to seconds not sprinting
		else {
			if (stamina < maxStamina) {
				stamina += (Time.deltaTime * staminaRecoveryFactor);
			}
		}

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
		localRB.velocity = new Vector2(frameHorizontalMoveSpeed, frameVerticalMoveSpeed) * sprintModifier;
		
		// Update rotation
		SetRotationOnMouse(); 
		
		// Ensure ammo didn't go past the limit
		if (ammo > maxAmmo) {
			ammo = maxAmmo;
		}

		// Shoot if keyShoot was clicked this frame
		if (Input.GetKeyDown(keyShoot)) {
			Shoot();
		}

		// Update ammo count in UIUpdater
		UI.inputAmmo = ammo;
		UI.inputMaxAmmo = maxAmmo;

		// Update stamina values in UIUpdater
		UI.inputStaminaMaxRatio = stamina / maxStamina;
	}

	void Shoot() {
		if (ammo > 0) {
			ammo -= 1;
			GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
			Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
			projectile.GetComponent<ProjectileBehaviour>().player = gameObject;
			projectile.GetComponent<ProjectileBehaviour>().isFriendly = true;
			projectile.GetComponent<ProjectileBehaviour>().damage = attackDamage;
			projectile.GetComponent<ProjectileBehaviour>().speed = projectileSpeed;
			projectile.GetComponent<ProjectileBehaviour>().Initialize();
		}
	}

	void SetRotationOnMouse() {
		// Get the mouse position in world coordinates, on the z=0 plane
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPos.z = 0; 

		// Rotate at mouseWorldPos by setting the right direction (front of the player sprite) to the direction between transform.position and mouseWorldPos
		transform.right = mouseWorldPos - transform.position;
	}
}
