using System.Collections.Generic;
using UnityEngine;

namespace menu {
	public class SubmenuManager : MonoBehaviour
	{
		public List<MenuComponent> menuComponents = new List<MenuComponent>();

		public void ShowHideSubmenu(submenus submenu) {
			Debug.Log(submenu);
			foreach (MenuComponent component in menuComponents) {
				if (!component.persistent) {
					if (component.memberOfSubmenu == submenu) {
						component.ShowHide(true);
						Debug.Log("Showing " + component.gameObject.name);
					}
					else {
						component.ShowHide(false);
						Debug.Log("Hiding " + component.gameObject.name);
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
