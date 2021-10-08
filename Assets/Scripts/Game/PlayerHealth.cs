using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public UIUpdater UI;
	public float health;
	public float maxHealth;
	public float damagelessTimeBeforeHeal;
	public float healPerSecond;

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

		if (Input.GetKeyDown(KeyCode.Space)) {
			Hurt(10);
		}
	}

	public void Hurt(float damage) {
		health -= damage;
		StopAllCoroutines();
		StartCoroutine(HealOverTime(damagelessTimeBeforeHeal, healPerSecond));
	}

	public void Heal(float heal) {
		health += heal;
	}

	IEnumerator HealOverTime(float timeBeforeHeal, float healPerSecond) {
		yield return new WaitForSeconds(timeBeforeHeal);
		
		while (true) {
			Heal(healPerSecond);
			yield return new WaitForSeconds(1f);
		}
	}
}
