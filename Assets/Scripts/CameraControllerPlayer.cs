using UnityEngine;

public class CameraControllerPlayer : MonoBehaviour
{
	public GameObject player;
	public float lookAheadStrength;

	void LateUpdate() {
		Vector2 playerPos = player.transform.position;
		Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();

		Vector2 newCameraPos = playerPos + playerRB.velocity * lookAheadStrength;

		float newX = Mathf.Lerp(transform.position.x, newCameraPos.x, 0.1f);
		float newY = Mathf.Lerp(transform.position.y, newCameraPos.y, 0.1f);

		transform.position = new Vector3(newX, newY, -10);
	}
}
