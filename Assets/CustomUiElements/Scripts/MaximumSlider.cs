using UnityEngine;
using UnityEngine.UI;

public class MaximumSlider : Slider
{
    public MinimumSlider MinSlider;
    public Text Indicator;
    public bool UseIndicator = true;

    public float RealValue;
    private bool assignedRealValue = false;

    protected override void Start()    
    {
        RealValue = maxValue;
        base.Start();
    }

    protected override void Set(float input, bool sendCallback)
    {
        UseIndicator = true;
        if (MinSlider == null)
        {
            foreach (Transform child in transform.parent)
            {
                if (child.gameObject.name != gameObject.name)
                {
                    MinSlider = child.GetComponent<MinimumSlider>();
                }
            }
        }
        if (UseIndicator && Indicator == null)
        {
            Indicator = transform.FindChild("Handle Slide Area").FindChild("Handle").FindChild("Indicator").gameObject.GetComponent<Text>();
            if (Indicator == null)
                Debug.Log(" es ull");
            else
                Debug.Log("no null");
        }
        if (!assignedRealValue)
        {
            RealValue = maxValue;
            assignedRealValue = true;
        }
        else
        {
            RealValue = maxValue - input + minValue;
        }

        if (wholeNumbers)
        {
            RealValue = Mathf.Round(RealValue);
        }
        if (RealValue <= MinSlider.value)
        {
            // invalid value
            return;
        }
        if (UseIndicator)
        {
            Indicator.text = "" + RealValue;
        }
        base.Set(input, sendCallback);
    }

    public void Refresh(float input)
    {
        Set(input, false);
    }
}