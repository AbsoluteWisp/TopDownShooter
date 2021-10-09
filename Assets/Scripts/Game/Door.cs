using UnityEngine;

public class Door : MonoBehaviour
{
	bool isOpen = true;
	Animator localAC;

	void Start() {
		localAC = gameObject.GetComponent<Animator>();
	}

	public void OpenClose(bool shouldOpen) {
		// Only execute if door state changes
		if (shouldOpen != isOpen) {
			isOpen = shouldOpen;

			localAC.ResetTrigger("Open");
			localAC.ResetTrigger("Close");
			
			if (shouldOpen) {
				localAC.SetTrigger("Open");
			}
			else {
				localAC.SetTrigger("Close");
			}
		}
	}
}
