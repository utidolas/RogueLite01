using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseScript pause_script;

    private void Awake()
    {
        pause_script = GetComponent<PauseScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(panel.activeInHierarchy == false)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void OpenMenu()
    {
        panel.SetActive(true);
        pause_script.PauseGame();
    }

    public void CloseMenu()
    {
        panel.SetActive(false);
        pause_script.UnpauseGame();
    }
}
