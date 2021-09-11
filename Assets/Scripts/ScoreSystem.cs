using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
	[Header("Basic score data")]
	public long score;
	public float multiplier;
	public float maxMultiplier;
	public float minMultiplier;
	public float multiplierStep;
	public float timerTime;

	[Header("Assign these: score for certain actions")]
	public long rewardEnemyHit;
	public long rewardEnemyKill;
	public long rewardRoomClear;

	public enum pointReasons {
		enemyHit,
		enemyKilled,
		roomCleared,
	}

	// Private timer data and UIUpdater reference
	private UIUpdater UI;
	private float timer = 0f;

	void Start() {
		UI = gameObject.GetComponent<UIUpdater>();
		multiplier = minMultiplier;
	}

	void Update() {
		if (multiplier != minMultiplier) {
			TimerTick();
		}

		// UI Updater: Basic scoring
		UI.inputMultiplier = multiplier;
		UI.inputScore = score;

		// UI Updater: Multiplier timer slider
		UI.inputMultiplierTimeRatio = timer / timerTime;
	}

	void TimerTick() {
		// Simple deltaTime-based timer for multipliers
		timer -= Time.deltaTime;
		
		if (timer <= 0) {
			// If timer expired, decrease multiplier and reset timer
			multiplierChange(false);
			timer = timerTime;
		}
	}

	public void RewardPlayer(pointReasons reason) {
		switch (reason) {
			case pointReasons.enemyHit:
				IncreaseScore(rewardEnemyHit);
				break;
			case pointReasons.enemyKilled:
				IncreaseScore(rewardEnemyKill);
				multiplierChange(true);
				break;
			case pointReasons.roomCleared:
				IncreaseScore(rewardRoomClear);
				break;
		}
		Debug.Log("Player awarded points for " + reason);
	}

	void IncreaseScore(long awardScore) {
		score += (long)(awardScore * multiplier);
	}

	void multiplierChange(bool increase) {
		if (increase) {
			multiplier += multiplierStep;
			timer = timerTime;
		}
		else {
			multiplier -= multiplierStep;
			timer = timerTime;
		}

		// Prevent the multiplier exceeding the min- or max-Multiplier limits
		if (multiplier < minMultiplier) {
			multiplier = minMultiplier;
		}
		if (multiplier > maxMultiplier) {
			multiplier = maxMultiplier;
		}
	}
}
