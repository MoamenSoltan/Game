using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;                  // Controls the main red fill
    public Image trailingFill;            // Pale white fill behind, controlled manually
    public float delaySpeed = 2f;         // Speed of trailing catch-up

    private float targetFill = 1f;        // Target fill (normalized 0–1)

    void Start()
    {
        targetFill = slider.value / slider.maxValue;
        trailingFill.fillAmount = targetFill;
    }

    public void SetHealth(float value)
    {
        // Set the main slider
        slider.value = value;

        // Update the target fill amount
        targetFill = value / slider.maxValue;
    }

    void Update()
    {
        if (trailingFill.fillAmount > targetFill)
        {
            trailingFill.fillAmount = Mathf.Lerp(trailingFill.fillAmount, targetFill, Time.deltaTime * delaySpeed);
        }
        else
        {
            trailingFill.fillAmount = targetFill; // Snap if healing
        }
    }
}
