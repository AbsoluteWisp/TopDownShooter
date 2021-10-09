using UnityEngine;

namespace options {
	public class FullscreenButton : MonoBehaviour {
		public OptionsFullscreen fsOption;
		public FullScreenMode fsMode;

		public void SetFullscreen() {
			fsOption.SetFullscreen(fsMode);
		}
	}	
}
