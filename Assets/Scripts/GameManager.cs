using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Canvas gameCanvas;
    [SerializeField]private Canvas menuCanvas;
    [SerializeField]private GameUI gameUI;
    [SerializeField]private GameObject menuPanel;
    [SerializeField]private GameObject levelSelectionPanel;
    [SerializeField]private GameObject pauseMenu;
    [SerializeField]private GameObject settingsPanel;
    [SerializeField]private GameObject quitConfirmationPanel;
    [field: SerializeField]public bool GameIsActive{get; set;}
    public static GameManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        ActivateMenu();
    }
    private void Update() 
    {
        ESCKeyPressed();
    }

    public void ActivateGame()
    {     
        gameCanvas.gameObject.SetActive(true);
        menuCanvas.gameObject.SetActive(false);
        GameIsActive = true;
    }
    public void ActivateMenu()
    {
        menuCanvas.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(false);
        menuPanel.SetActive(true);
        levelSelectionPanel.SetActive(false);
        GameIsActive = false;
    }

    public void StartLevel(int level)
    {
        WaypointManager.instance.SetCurrentPath(level);
        SceneManager.LoadScene(level);
        gameUI.ResetValuesOnNewLevel(level);
        AuraManager.ClearTowerList();
        ActivateGame();
    }
    
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
        ActivateMenu();
    }

    public void OpenLevelSelection()
    {
        SwitchGameobjectState(menuPanel);
        SwitchGameobjectState(levelSelectionPanel);
    }

    private void ESCKeyPressed()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!GameIsActive)
            {
                if(levelSelectionPanel.activeInHierarchy)
                {
                    SwitchGameobjectState(levelSelectionPanel);
                    SwitchGameobjectState(menuPanel);
                }
                else
                {
                    SwitchGameobjectState(quitConfirmationPanel);
                }
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

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
