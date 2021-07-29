using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
	public long score;

	private UIUpdater ui;
	private float timer = 0f;
	private float timerCap;

	void Start() {
		ui = gameObject.GetComponent<UIUpdater>();
	}

	void Update() {
		TimerTick();

	}

	void TimerTick() {
		// Simple deltaTime-based timer for multipliers
		timer += Time.deltaTime;
		
		if (timer >= timerCap) {
			timer = 0f;
			Debug.Log(timerCap + " seconds have passed");
		}
	}
}
