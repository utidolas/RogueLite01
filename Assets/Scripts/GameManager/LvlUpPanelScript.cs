using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUpPanelScript : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] PauseScript pause_script;

    public void OpenLvlUpPanel()
    {
        pause_script.PauseGame();
        panel.SetActive(true);
    }

    public void CloseLvlUpPanel()
    {
        pause_script.UnpauseGame();
        panel.SetActive(false);
    }
}
