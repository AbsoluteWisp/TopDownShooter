using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public List<MenuUIComponent> allUI = new List<MenuUIComponent>();
	public List<MenuUIComponent> submenuButtons = new List<MenuUIComponent>();
	public List<MenuUIComponent> playSubmenu = new List<MenuUIComponent>();
	public List<MenuUIComponent> achievementSubmenu = new List<MenuUIComponent>();
	public List<MenuUIComponent> optionSubmenu = new List<MenuUIComponent>();
	public List<MenuUIComponent> aboutSubmenu = new List<MenuUIComponent>();
	public List<MenuUIComponent> exitSubmenu = new List<MenuUIComponent>();

	public enum submenus {
		main,
		play,
		achievement,
		option,
		about,
		exit,
	}

	public void showSubmenu(submenus menuToShow) {
		foreach (MenuUIComponent uiElement in allUI) {
			uiElement.Hide();
		}

		switch (menuToShow) {
			case submenus.main:
				foreach (MenuUIComponent submenuElement in submenuButtons) {
					submenuElement.Show();
				}
				break;
			case submenus.play:
				foreach (MenuUIComponent submenuElement in playSubmenu) {
					submenuElement.Show();
				}
				break;
			case submenus.achievement:
				foreach (MenuUIComponent submenuElement in achievementSubmenu) {
					submenuElement.Show();
				}
				break;
			case submenus.option:
				foreach (MenuUIComponent submenuElement in optionSubmenu) {
					submenuElement.Show();
				}
				break;
			case submenus.about:
				foreach (MenuUIComponent submenuElement in aboutSubmenu) {
					submenuElement.Show();
				}
				break;
			case submenus.exit:
				foreach (MenuUIComponent submenuElement in exitSubmenu) {
					submenuElement.Show();
				}
				break;
		}
	}
}
