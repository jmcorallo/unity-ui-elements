using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUiElements
{
    public class MinMaxSlider : MonoBehaviour
    {
        [Header("Common settings")]
        public int DecimalPlaces = 2;
        public float MinimumValue = 0;
        public float MaximumValue = 1;
        public bool UseWholeNumbers = false;
        public bool ShowIndicators = true;

        [Header("Configuration for MinSlider")]
        public MinimumSlider MinSlider;
        [Tooltip("Leave null to disable")]
        public Text MinSliderIndicator;

        [Header("Configuration for MaxSlider")]
        public MaximumSlider MaxSlider;
        [Tooltip("Leave null to disable")]
        public Text MaxSliderIndicator;

        // Properties
        public float CurrentLowerValue
        {
            get { return MinSlider.value; }
        }
        public float CurrentUpperValue
        {
            get{ return MaxSlider.RealValue; }
        }

        void Awake()
        {
            // Define if we use indicators:
            if (ShowIndicators)
            {
                MinSlider.Indicator = MinSliderIndicator;
                MinSlider.NumberFormat = "n" + DecimalPlaces;
                MaxSlider.Indicator = MaxSliderIndicator;
                MaxSlider.NumberFormat = "n" + DecimalPlaces;
            }
            else
            {
                MinSliderIndicator.gameObject.SetActive(false);
                MaxSliderIndicator.gameObject.SetActive(false);
            }

            // Adjust Max/Min values for both sliders
            MinSlider.minValue = MinimumValue;
            MinSlider.maxValue = MaximumValue;
            MinSlider.wholeNumbers = UseWholeNumbers;

            MaxSlider.minValue = MinimumValue;
            MaxSlider.maxValue = MaximumValue;
            MaxSlider.wholeNumbers = UseWholeNumbers;
        }
    }
}