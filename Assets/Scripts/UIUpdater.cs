using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
	[Header("UI Elements")]
	public TextMeshProUGUI UIScore;
	public TextMeshProUGUI UIMultiplier;
	public Slider UIHealth;
	public TextMeshProUGUI UIAmmo;
	public TextMeshProUGUI UIMaxAmmo;

	public enum displayTargets {
		score,
		multiplier,
		health,
		ammo,
		maxAmmo
	}

	[Header("Score")]
	public long inputScore;
	public float inputMultiplier;
	
	[Header("Health bar")]
	public float fadeTime;
	public float inputHealth;
	public float inputMaxHealth;

	[Header("Ammo")]
	public int inputAmmo;
	public int inputMaxAmmo;

	private bool uncofiguredErrorThrown = false;
	private IEnumerator SmoothHealthCoroutine;

	void Start() {
		SmoothHealthCoroutine = SmoothHealth(UIHealth.value);
	}

	void Update() {
		UpdateUI(displayTargets.score);
		UpdateUI(displayTargets.multiplier);
		UpdateUI(displayTargets.health);
		UpdateUI(displayTargets.ammo);
		UpdateUI(displayTargets.maxAmmo);
	}

	void UpdateUI(displayTargets element) {
		switch (element) {
			case displayTargets.score:
				UIScore.text = "Score: " + inputScore;
				break;
			case displayTargets.multiplier:
				UIMultiplier.text = "Multiplier: " + inputMultiplier + "x";
				break;
			case displayTargets.health:
				SetHealthMax(inputMaxHealth);
				UIHealth.value = Mathf.MoveTowards(UIHealth.value, inputHealth, fadeTime * Time.deltaTime);
				break;
			case displayTargets.ammo:
				UIAmmo.text = inputAmmo.ToString();
				break;
			case displayTargets.maxAmmo:
				UIMaxAmmo.text = "/" + inputMaxAmmo;
				break;
			default:
				if (!uncofiguredErrorThrown) {
					Debug.LogError("Encountered displayTarget " + element +  " wasn't handled by the UI Updater @ UIUpdater.cs");
					uncofiguredErrorThrown = true;
				}
				break;
		}
	}

	public void SetHealthMax(float maxValue) {
		UIHealth.maxValue = maxValue;
	}

	IEnumerator SmoothHealth(float startValue) {
		float workingValue = startValue;
		float currentTime = 0f;
		
		while (currentTime < fadeTime) {
			var normalizedSmooth = currentTime / fadeTime;
			currentTime += Time.deltaTime;

			UIHealth.value = workingValue + (normalizedSmooth * (inputHealth - workingValue));

			yield return null;
		}
	}
}
