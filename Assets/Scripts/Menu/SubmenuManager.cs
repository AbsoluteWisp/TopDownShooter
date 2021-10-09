using System.Collections.Generic;
using UnityEngine;

namespace menu {
	public class SubmenuManager : MonoBehaviour
	{
		public List<MenuComponent> menuComponents = new List<MenuComponent>();

		public void ShowHideSubmenu(submenus submenu) {
			foreach (MenuComponent component in menuComponents) {
				if (!component.persistent) {
					if (component.memberOfSubmenu == submenu) {
						component.ShowHide(true);
					}
					else {
						component.ShowHide(false);
					}		
				}
			}
		}
	}

	public enum submenus {
		play,
		achievements,
		options,
		about,
		quit,
		// Vanity submenu, to indicate the fact this doesn't matter on persistent components
		NA,
	}
}
