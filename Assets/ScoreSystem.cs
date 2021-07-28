using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
	public float timer = 0f;
	public float timerCap;

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
