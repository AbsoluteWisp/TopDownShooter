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
	public string[] stats = new string[4];
	public bool isCleared;

	void Awake() {
		difficulty.text = stats[0];
		levelName.text = stats[1];
		bestTime.text = stats[2];
		bestScore.text = stats[3];
		if (isCleared) {
			cleared.sprite = clearedSprite;
		}
		else {
			cleared.sprite = notClearedSprite;
		}
	}
}
