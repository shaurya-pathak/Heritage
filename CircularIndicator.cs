using UnityEngine;
using UnityEngine.UI;

public class CircularIndicator : MonoBehaviour
{
    public Image[] circularBorderImages; // Assign an array of circular border images in the inspector

    void Start()
    {
        // Sample values for demonstration
        float[] sampleValues = new float[] { 10f, 45f, 70f, 85f, 33f, 47f, 98f, 22f }; // Sample values for each indicator
        SetIndicatorValues(sampleValues); // Update the indicators with sample values
    }

    public void SetIndicatorValues(float[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            // Assuming values are between 0 and 100
            float fillValue = values[i] / 100f;
            
            // Update the fill amount
            circularBorderImages[i].fillAmount = fillValue;

            // Update the color based on the value
            circularBorderImages[i].color = GetColorForValue(values[i]);
        }
    }

    private Color GetColorForValue(float value)
    {
        if (value <= 33.3f)
        {
            return Color.red;
        }
        else if (value <= 66.6f)
        {
            return Color.yellow;
        }
        else
        {
            return Color.green;
        }
    }
}
