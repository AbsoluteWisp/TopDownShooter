using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{	
	public Slider slider;
	public Gradient fillColorChange;
	public Image fillImage;

	void Update() {
		float sliderNormalized = slider.value / slider.maxValue;
		fillImage.color = fillColorChange.Evaluate(sliderNormalized);
	}
}
