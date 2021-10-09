using UnityEngine;

public class DataManager : MonoBehaviour
{
	static int levelCount = 10;
	
	public float[] times = new float[levelCount];
	public int[] scores = new int[levelCount];
	public bool[] cleared = new bool[levelCount];

	[Header("Level metadata")]
	public string[] difficulties = new string[levelCount];
	public string[] names = new string[levelCount];

	void Awake() {
		DontDestroyOnLoad(this.gameObject);

		if(!LoadStats()) {
			CreateBlankSave();		
		}
	}

	void CreateBlankSave() {
		float[] blankTimes = new float[levelCount];
		int[] blankScores = new int[levelCount];
		bool[] blankCleared = new bool[levelCount];

		for (int i = 0; i < levelCount; i++) {
			blankTimes[i] = -1f;
			blankScores[i] = -1;
			blankCleared[i] = false;
		}

		SaveStats(blankTimes, blankScores, blankCleared);
	}

	public void SaveStats(float[] eTimes, int[] eScores, bool[] eCleared) {
		SaveSystem.SaveStats(eTimes, eScores, eCleared);
	}

	public bool LoadStats() {
		StatsData data = SaveSystem.LoadStats();

		if (data == null) {
			return false;
		}
		else {
			times = data.times;
			scores = data.scores;
			cleared = data.cleared;
			return true;	
		}
	}

	public string GetDifficulty(int id) {
		return difficulties[id];
	}

	public string GetName(int id) {
		return names[id];
	}
}
