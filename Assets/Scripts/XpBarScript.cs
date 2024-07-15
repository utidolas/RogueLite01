using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBarScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    public void UpdateXpBar(float current, float xpNeeded)
    {
        slider.value = current;
        slider.maxValue = xpNeeded;
    }

    public void UpdateLevelText(int level)
    {
        levelText.text = "LEVEL " + level.ToString();
    }
}
