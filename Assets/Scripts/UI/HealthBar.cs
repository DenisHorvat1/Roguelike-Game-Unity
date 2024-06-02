using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        text.text = health.ToString();
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        text.text = health.ToString("F0");
    }

}
