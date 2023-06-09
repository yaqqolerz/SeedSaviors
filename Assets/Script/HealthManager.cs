using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slidervalue;
    public Gradient gr;
    public Image fill;

    public void SetMaxHealth(float healthValue)
    {
        slidervalue.maxValue = healthValue;
        slidervalue.value = healthValue;
        fill.color = gr.Evaluate(1f);
    }

    public void SetHealth(float healthValue)
    {
        slidervalue.value = healthValue;
        fill.color = gr.Evaluate(slidervalue.normalizedValue);
    }
}
