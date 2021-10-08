using System;

[Serializable]
public class StatsData
{
	// time as seconds, score as points, cleared as true if level is cleared)
	public float[] times;
	public int[] scores;
	public bool[] cleared;

	public StatsData(float[] cTimes, int[] cScores, bool[] cCleared) {
		times = cTimes;
		scores = cScores;
		cleared = cCleared;
	}
}
