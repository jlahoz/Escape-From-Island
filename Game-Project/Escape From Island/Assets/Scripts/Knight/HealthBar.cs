using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    // Cambiar de color la barra en funcion de la vida del jugador.
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        // Con la barra al maximo toma el valor maximo de color.
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth (int health)
    {
        slider.value = health;
        
        // En funcion de la vida toma un valor que equivale a un color diferente
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
