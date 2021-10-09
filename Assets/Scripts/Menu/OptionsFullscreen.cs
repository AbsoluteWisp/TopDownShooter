using UnityEngine;

namespace options {
	public class OptionsFullscreen : MonoBehaviour {
		public void SetFullscreen(FullScreenMode fsMode) {
			if (Screen.fullScreenMode != fsMode) {
				Screen.fullScreenMode = fsMode;
			}
		}
	}
}

