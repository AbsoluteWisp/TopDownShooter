using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
	public string prefsKeyName;

	public void EnterLevel(int id) {
		PlayerPrefs.SetInt(prefsKeyName, id);

		gameObject.GetComponent<SceneSwitcher>().Switch(1);
	}
}
