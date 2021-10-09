using UnityEngine;

public class LevelMaintenance : MonoBehaviour
{
	DataManager dataMgr;

	private bool timerRunning = true;
	public float levelTimer = 0f;

	void Start() {
		dataMgr = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
	}

	public void FinishLevel() {
		int levelID = gameObject.GetComponent<LevelLoader>().levelID;
		float finalTime = levelTimer;
		int finalScore = gameObject.GetComponent<ScoreSystem>().score;

		if (dataMgr.times[levelID] != -1) {
			if (finalTime < dataMgr.times[levelID]) {
				dataMgr.times[levelID] = finalTime;
			}
		}
		else {
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
