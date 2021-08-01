using UnityEngine;

public class MenuReturnButton : MonoBehaviour
{
	MenuController controller;

	void Start() {
		controller = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
	}

	public void OnClick() {
		controller.showSubmenu(MenuController.submenus.main);
	}
}
