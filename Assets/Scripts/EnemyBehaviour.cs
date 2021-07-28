using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	// Private data
	private Rigidbody2D LocalRB;

	void Awake() {
		LocalRB = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update() {
		
	}

	public void OnHit() {
		
	}
}
