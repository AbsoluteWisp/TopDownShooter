using UnityEngine;

public class LevelLoader : MonoBehaviour
{
	public string prefsKeyName;
	public GameObject[] levelPrefabs;

	void Awake() {
		LoadLevel(PlayerPrefs.GetInt(prefsKeyName));
	}

	public void LoadLevel(int id) {
		Instantiate(levelPrefabs[id], new Vector3(0,0,0), Quaternion.identity);
	}
}
