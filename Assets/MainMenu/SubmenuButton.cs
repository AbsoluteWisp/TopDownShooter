using UnityEngine;

public class SubmenuButton : MonoBehaviour
{
	public MenuController.submenus submenuToOpen;
	MenuController controller;

	void Start() {
		controller = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
	}

	public void OnClick() {
		controller.showSubmenu(submenuToOpen);
	}
}
