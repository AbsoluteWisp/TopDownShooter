using UnityEngine;

public class CameraControllerRoom : MonoBehaviour
{
	public Vector2 targetPos;

	void LateUpdate() {
		Vector2 newCameraPos = targetPos;

		float newX = Mathf.Lerp(transform.position.x, newCameraPos.x, 0.1f);
		float newY = Mathf.Lerp(transform.position.y, newCameraPos.y, 0.1f);

		transform.position = new Vector3(newX, newY, -10);
	}
}
