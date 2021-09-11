using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	public Animator transitionAnimator;
	public AnimationClip sceneExitClip;

	private float exitClipLength;

	void Start() {
		transitionAnimator.ResetTrigger("TransitionOut");
		exitClipLength = sceneExitClip.length;
	}

	public void Switch(int index) {
		StartCoroutine(SwitchScene(index));
	}

	IEnumerator SwitchScene(int index) {
		transitionAnimator.SetTrigger("TransitionOut");
		yield return new WaitForSeconds(exitClipLength);
		SceneManager.LoadSceneAsync(index);		
	}
}
