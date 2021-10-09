using UnityEngine;

public class LevelLoader : MonoBehaviour
{
	public string prefsKeyName;
	public GameObject[] levelPrefabs;

	public int levelID;

	void Awake() {
		LoadLevel(PlayerPrefs.GetInt(prefsKeyName));
	}

	public void LoadLevel(int id) {
		levelID = id;
		Instantiate(levelPrefabs[id], new Vector3(0,0,0), Quaternion.identity);
	}
}
