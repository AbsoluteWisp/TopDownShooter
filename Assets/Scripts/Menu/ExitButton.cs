using UnityEngine;

namespace menu {
	public class ExitButton : MonoBehaviour {
		public void ExitGame() {
			Application.Quit(0);
		}
	}
}

