using UnityEngine;

public class MenuUIComponent : MonoBehaviour
{
	public bool showOnSceneLoad;
	private CanvasGroup canvasGroup;

	void Awake() {
		canvasGroup = gameObject.GetComponent<CanvasGroup>();

		if (showOnSceneLoad) {
			Show();
		}
		else {
			Hide();
		}
	}

	public void Hide() {
		canvasGroup.interactable = false;
		canvasGroup.alpha = 0f;
	}

	public void Show() {
		canvasGroup.interactable = true;

		
		canvasGroup.alpha = 1f;
	}
}
