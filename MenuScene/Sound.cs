using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Slider slider;
    public string name;
    private TextMeshProUGUI percentageText;

    void Start()
    {
        percentageText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        float maxVolume = slider.maxValue;
        float minVolume = slider.minValue;

        float value = slider.value;
        int percentage = CalculatePercentage(minVolume, maxVolume, value);

        if (percentageText != null)
            percentageText.text = name + " " + percentage.ToString() + "%";
        else
            Debug.LogWarning("TextMeshProUGUI component not assigned!");
    }

    int CalculatePercentage(float min, float max, float value)
    {
        if (value < min || value > max)
        {
            Debug.LogError("Value is not between min and max!");
            return -1;
        }

        float percentage = (value - min) / (max - min) * 100f;
        return Mathf.RoundToInt(percentage);
    }
}
