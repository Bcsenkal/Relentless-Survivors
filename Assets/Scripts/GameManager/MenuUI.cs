using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField]private GameObject menuPanel;
    [SerializeField]private GameObject levelSelectionPanel;
    [SerializeField]private GameObject settingsPanel;
    [SerializeField]private GameObject quitConfirmationPanel;
    private void OnEnable() 
    {
        menuPanel.SetActive(true);
        levelSelectionPanel.SetActive(false);
        settingsPanel.SetActive(false);
        quitConfirmationPanel.SetActive(false);
    }

    private void Update() 
    {
        ESCKeyPressed();
    }

    private void ESCKeyPressed()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(levelSelectionPanel.activeInHierarchy)
            {
                levelSelectionPanel.SetActive(false);
                menuPanel.SetActive(true);
            }
            else if(settingsPanel.activeInHierarchy)
            {
                settingsPanel.SetActive(false);
                menuPanel.SetActive(true);
            }
            else
            {
                if(!quitConfirmationPanel.activeInHierarchy)
                {
                    quitConfirmationPanel.SetActive(true);
                }
                else
                {
                    quitConfirmationPanel.SetActive(false);
                }
            }
        }
    }
    //Basic gameobject activate/deactivate function for buttons
    public void SwitchGameobjectState(GameObject panel)
    {
        if(panel.activeInHierarchy)
        {
            panel.SetActive(false);
        }
        else if(!panel.activeInHierarchy)
        {
            panel.SetActive(true);
        }
    }
}
