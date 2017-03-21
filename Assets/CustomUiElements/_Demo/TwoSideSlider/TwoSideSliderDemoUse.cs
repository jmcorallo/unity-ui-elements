using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomUiElements;

public class TwoSideSliderDemoUse : MonoBehaviour
{
    public Text ResultText;
    public MinMaxSlider Sliders;
	
    public void ButtonClick()
    {
        ResultText.text = string.Format("The lower value is {0} and the upper value is {1}",
            Sliders.CurrentLowerValue, Sliders.CurrentUpperValue);
    }
}
