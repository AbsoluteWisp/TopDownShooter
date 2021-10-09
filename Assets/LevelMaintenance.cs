using UnityEngine;

public class LevelMaintenance : MonoBehaviour
{
	DataManager dataMgr;

	private bool timerRunning = true;
	private float levelTimer = 0f;

	void Start() {
		dataMgr = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
	}

	public void FinishLevel() {
		int levelID = gameObject.GetComponent<LevelLoader>().levelID;
		float finalTime = levelTimer;
		int finalScore = gameObject.GetComponent<ScoreSystem>().score;

		if (finalTime < dataMgr.times[levelID]) {
			dataMgr.times[levelID] = finalTime;
		}
		if (finalScore > dataMgr.scores[levelID]) {
			dataMgr.scores[levelID] = finalScore;
		}

		dataMgr.cleared[levelID] = true;

		dataMgr.SaveStats(dataMgr.times, dataMgr.scores, dataMgr.cleared);
	}

	void Update() {
		if (timerRunning) {
			levelTimer += Time.deltaTime;
		}
	}
}
