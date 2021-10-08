using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace menu {
	public class SubmenuButton : MonoBehaviour
	{
		public submenus submenuToOpen;
		public SubmenuManager manager;

		public void OpenSubmenu() {
			manager.ShowHideSubmenu(submenuToOpen);
		}
	}	
}

