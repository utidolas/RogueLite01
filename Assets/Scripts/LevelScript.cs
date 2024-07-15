using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public int level = 1;
    public float experience = 0f;
    [SerializeField] XpBarScript XpBar_script;
    [SerializeField] LvlUpPanelScript LvlUpPanel_script;

    public float XP_TO_LEVELUP
    {
        get
        {
            return level * 1000f * 1.25f;
        }
    }
    private void Start()
    {
        XpBar_script.UpdateXpBar(experience, XP_TO_LEVELUP);
        XpBar_script.UpdateLevelText(level);
    }

    public void AddExp(float amount)
    {
        experience += amount;
        UpdateLevel();
        XpBar_script.UpdateXpBar(experience, XP_TO_LEVELUP);
    }

    private void UpdateLevel() 
    {
        if(experience >= XP_TO_LEVELUP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        LvlUpPanel_script.OpenLvlUpPanel();
        level++;
        experience = 0f;
        XpBar_script.UpdateLevelText(level);
    }
}
