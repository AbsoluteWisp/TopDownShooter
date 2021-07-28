using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIUpdater : MonoBehaviour
{
	[Header("UI Elements")]
	public TextMeshProUGUI UIScore;
	public TextMeshProUGUI UIMultiplier;
	public Slider UIHealth;

	public enum displayTargets {
		score,
		multiplier,
		health
	}

	[Header("Data")]
	public long inputScore;
	public int inputMultiplier;

	private bool uncofiguredErrorThrown = false;

	void Update() {
		UpdateUI(displayTargets.score);
		UpdateUI(displayTargets.multiplier);
		UpdateUI(displayTargets.health);
	}

	void UpdateUI(displayTargets element) {
		switch (element) {
			case displayTargets.score:
				UIScore.text = "Score: " + inputScore;
				break;
			case displayTargets.multiplier:
				UIMultiplier.text = "Multiplier: " + inputMultiplier + "x";
				break;
			default:
				if (!uncofiguredErrorThrown) {
					Debug.LogError("Encountered displayTarget wasn't handled by the UI Updater @ UIUpdater.cs:26");
					uncofiguredErrorThrown = true;
				}
				break;
		}
	}
}
