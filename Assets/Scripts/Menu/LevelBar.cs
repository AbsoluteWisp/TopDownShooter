using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This class is responsible for displaying level stats on their UI "bars"
public class LevelBar : MonoBehaviour
{
	[Header("Output components")]
	public TextMeshProUGUI difficulty;
	public TextMeshProUGUI levelName;
	public TextMeshProUGUI bestTime;
	public TextMeshProUGUI bestScore;
	public Image cleared;
	public Sprite notClearedSprite;
	public Sprite clearedSprite;

	[Header("Input")]
	public int levelID;
	public DataManager dataMgr;

	void Start() {
		dataMgr.LoadStats();

		if (dataMgr.GetDifficulty(levelID) != null) {
			difficulty.text = dataMgr.GetDifficulty(levelID);
		}
		else {
			difficulty.text = "N/A";
		}

		if (dataMgr.GetName(levelID) != null) {
			levelName.text = dataMgr.GetName(levelID);
		}
		else {
			levelName.text = "N/A";
		}


		if (dataMgr.times[levelID] != -1f) {
			bestTime.text = TimePrettyPrint(dataMgr.times[levelID]);
		}
		else {
			bestTime.text = "N/A";
		}

		if (dataMgr.scores[levelID] != -1) {
			bestScore.text = dataMgr.scores[levelID].ToString();
		}
		else {
			bestScore.text = "N/A";
		}
		
		cleared.sprite = PickClearedSprite(dataMgr.cleared[levelID]);
	}

	string TimePrettyPrint(float timeSeconds) {
		float minutes = Mathf.Floor(timeSeconds / 60);
		float seconds = Mathf.Floor(timeSeconds - (minutes * 60));
		float secondFractions = timeSeconds - (minutes * 60) - seconds;

		return minutes + ":" + seconds + "," + secondFractions;
	}

	Sprite PickClearedSprite(bool cleared) {
		if (cleared == true) {
			return clearedSprite;
		}
		else {
			return notClearedSprite;
		}
	}
}
