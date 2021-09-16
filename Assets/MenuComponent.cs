using UnityEngine;

namespace menu {
	public class MenuComponent : MonoBehaviour {
		public bool persistent;
		public submenus memberOfSubmenu;

		public bool enterOnSceneLoad;

		private Animator localAC;
		private bool isShown = false;

		void Awake() {
			localAC = gameObject.GetComponent<Animator>();

			if (enterOnSceneLoad) {
				ShowHide(true);
			}
			else {
				Animate("FadeOutInstant");
			}
		}

		public void ShowHide(bool show) {
			if (show && !isShown) {
				Animate("FadeIn");
				isShown = true;
			}
			if (!show && isShown) {
				Animate("FadeOut");
				isShown = false;
			}
		}

		void Animate(string trigger) {
			localAC.ResetTrigger("FadeIn");
			localAC.ResetTrigger("FadeOut");
			localAC.ResetTrigger("FadeOutInstant");

			localAC.SetTrigger(trigger);
		}
	}
}

