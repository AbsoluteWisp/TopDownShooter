using UnityEngine;

namespace options {
	public class OptionsResolution : MonoBehaviour {
		public void SetResolution(int width, int height) {
			if (Screen.currentResolution.width != width || Screen.currentResolution.height != height) {
				Screen.SetResolution(width, height, Screen.fullScreenMode, 0);
			}
		}
	}
}

