using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public float health;
	public float maxHealth;
	public float attackDamage;

	private GameObject gameManager;
	private ScoreSystem scoreSystem;

	void Awake() {
		health = maxHealth;
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		scoreSystem = gameManager.GetComponent<ScoreSystem>();
	}

	void Update() {
		if (health <= 0) {
			scoreSystem.RewardPlayer(ScoreSystem.pointReasons.enemyKilled);
			Destroy(gameObject);
		}
	}

	public void OnHit(float damage) {
		health -= damage;

		scoreSystem.RewardPlayer(ScoreSystem.pointReasons.enemyHit);
	}
}
