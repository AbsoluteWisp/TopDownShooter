using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public bool isActive = false;
	public Room memberOfRoom;
	public float health;
	public float maxHealth;
	public float attackDamage;
	public float projectileSpeed;
	public GameObject projectilePrefab;
	public float attackTimerCap;

	private GameObject gameManager;	
	private GameObject player;
	private Vector3 predictedPlayerPos;
	private Rigidbody2D playerRB;
	private ScoreSystem scoreSystem;
	private float attackTimer = 0f;

	void Awake() {
		health = maxHealth;
		player = GameObject.FindGameObjectWithTag("Player");
		playerRB = player.GetComponent<Rigidbody2D>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		scoreSystem = gameManager.GetComponent<ScoreSystem>();
	}

	// Late to make sure player movement happens earlier
	void LateUpdate() {
		if (isActive) {
			predictedPlayerPos = predictPos(playerRB);
			RotateTowards(predictedPlayerPos);

			TimerTick();		
		}
	}

	void Shoot() {
		GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
		Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
		projectile.GetComponent<ProjectileBehaviour>().predictedPlayerPos = predictedPlayerPos;
		projectile.GetComponent<ProjectileBehaviour>().speed = projectileSpeed;
		projectile.GetComponent<ProjectileBehaviour>().damage = attackDamage;
		projectile.GetComponent<ProjectileBehaviour>().Initialize();
	}

	public void OnHit(float damage) {
		health -= damage;
		scoreSystem.RewardPlayer(ScoreSystem.pointReasons.enemyHit);

		// Activates this single enemy when attacked
		if (!isActive) {
			isActive = true;
		}
		
		if (health <= 0) {
			scoreSystem.RewardPlayer(ScoreSystem.pointReasons.enemyKilled);
			memberOfRoom.RemoveEnemy(this);

			Destroy(gameObject);
		}
	}

	void RotateTowards(Vector3 pos) {
		pos.z = 0;

		Vector3 direction = pos - transform.position;
		transform.right = direction;
	}

	void TimerTick() {
		attackTimer += Time.deltaTime;

		if (attackTimer >= attackTimerCap) {
			attackTimer = 0f;
			Shoot();
		}
	}

	Vector3 predictPos(Rigidbody2D predictableBody) {
		Vector3 predictableBodyPos = predictableBody.position;
		Vector3 predictableBodyDir = predictableBody.velocity;

		float distanceToPredictableBody = Vector3.Distance(transform.position, predictableBodyPos);
		
		return predictableBodyPos + (distanceToPredictableBody / projectileSpeed) * predictableBodyDir;
 	}
}
