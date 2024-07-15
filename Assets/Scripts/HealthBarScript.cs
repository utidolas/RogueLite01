using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Camera mainCam;

    public void UpdateHealthBar(float current, float max)
    {
        healthBar.maxValue = max;
        healthBar.value = current;
    }

    private void Update()
    {
        transform.rotation = mainCam.transform.rotation;
    }
}
