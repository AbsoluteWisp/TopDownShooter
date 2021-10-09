using UnityEngine;

namespace options {
	public class ResolutionButton : MonoBehaviour {
		public OptionsResolution resolutionOption;
		public int width;
		public int height;

		public void SetResolution() {
			resolutionOption.SetResolution(width, height);
		}
	}	
}

