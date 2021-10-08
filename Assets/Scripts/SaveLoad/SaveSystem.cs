using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	static string savePath = Application.persistentDataPath + "/stats.sav";

	public static void SaveStats(float[] cTimes, int[] cScores, bool[] cCleared) {
		BinaryFormatter formatter = new BinaryFormatter();
		
		using (FileStream stream = new FileStream(savePath, FileMode.Create)) {
			StatsData dataToSave = new StatsData(cTimes, cScores, cCleared);
			formatter.Serialize(stream, dataToSave);
		}
	}

	public static StatsData LoadStats() {
		if (File.Exists(savePath)) {
			BinaryFormatter formatter = new BinaryFormatter();
		
			using (FileStream stream = new FileStream(savePath, FileMode.Open)) {
				return formatter.Deserialize(stream) as StatsData;
			}
		}
		else {
			return null;
		}
	}
}
