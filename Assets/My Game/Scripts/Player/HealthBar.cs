using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderHealth;
    public TextMeshProUGUI textHealth;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();

        if(playerHealth != null)
        {
            sliderHealth.maxValue = playerHealth.maxHealth;
            sliderHealth.maxValue = sliderHealth.maxValue;
        }
    }

    private void Update()
    {
        sliderHealth.value = playerHealth.currentHealth;
    }

}
