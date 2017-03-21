using UnityEngine;
using UnityEngine.UI;

public class MinimumSlider : Slider
{
    public MaximumSlider MaxSlider;
    public Text Indicator;
    public bool UseIndicator = true;

    protected override void Set(float input, bool sendCallback)
    {
        if (MaxSlider == null)
        {
            foreach (Transform child in transform.parent)
            {
                if (child.gameObject.name != gameObject.name)
                {
                    MaxSlider = child.GetComponent<MaximumSlider>();
                }
            }
        }
        if (UseIndicator && Indicator == null)
        {
            Indicator = transform.FindChild("Handle Slide Area").FindChild("Handle").FindChild("Indicator").gameObject.GetComponent<Text>();
        }

        float newValue = input;
        if (wholeNumbers)
        {
            newValue = Mathf.Round(newValue);
        }
        if (newValue >= MaxSlider.RealValue && MaxSlider.RealValue != MaxSlider.minValue)
        {
            // invalid
            return;
        }
        if (UseIndicator)
        {
            Indicator.text = "" + newValue;
        }
        base.Set(input, sendCallback);
    }

    public void Refresh(float input)
    {
        Set(input, false);
    }
}