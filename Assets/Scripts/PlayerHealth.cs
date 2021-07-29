using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public UIUpdater UI;
	public float health;
	public float maxHealth;

	void Start() {
		health = maxHealth;
	}

	void Update() {
		// Prevent health going past the max
		if (health > maxHealth) {
			health = maxHealth;	
		}

		UI.inputHealth = health;
		UI.inputMaxHealth = maxHealth;
	}

	public void Hurt(float damage) {
		health -= damage;
	}

	public void Heal(float heal) {
		health += heal;
	}
}
