using UnityEngine;

public class LevelGoal : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player")) {
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelMaintenance>().FinishLevel();
		}
	}
}
