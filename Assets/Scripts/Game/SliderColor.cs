using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{	
	public Slider slider;
	public Gradient fillColorChange;
	public Image fillImage;

	void Update() {
		float sliderNormalized = slider.value / slider.maxValue;

		if (sliderNormalized < 0) {
			sliderNormalized = 0;
		}
		fillImage.color = fillColorChange.Evaluate(sliderNormalized);
	}
}
