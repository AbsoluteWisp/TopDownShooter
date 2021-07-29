using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
	[Header("Basic score data")]
	public long score;
	public float multiplier;
	public float maxMultiplier;
	public float minMultiplier;
	public float multiplierStep;
	public float timerCap;

	[Header("Assign these: score for certain actions")]
	public long rewardEnemyHit;
	public long rewardEnemyKill;
	public long rewardMultiplierIncrease;
	public long rewardRoomClear;

	public enum pointReasons {
		enemyHit,
		enemyKilled,
		multiplierIncreased,
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

		UI.inputMultiplier = multiplier;
		UI.inputScore = score;
	}

	void TimerTick() {
		// Simple deltaTime-based timer for multipliers
		timer += Time.deltaTime;
		
		if (timer >= timerCap) {
			// If timer expired, decrease multiplier and reset timer
			multiplierChange(false);
			timer = 0f;
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
				Debug.Log("stepped up multiplier");
				break;
			case pointReasons.multiplierIncreased:
				IncreaseScore(rewardMultiplierIncrease);
				break;
		}
	}

	void IncreaseScore(long awardScore) {
		score += (long)(awardScore * multiplier);
	}

	void multiplierChange(bool increase) {
		if (increase) {
			multiplier += multiplierStep;
			timer = 0f;
			Debug.Log("right now");
		}
		else {
			multiplier -= multiplierStep;
			timer = 0f;
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
