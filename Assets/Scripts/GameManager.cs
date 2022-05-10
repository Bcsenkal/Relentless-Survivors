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
    [SerializeField]private GameObject pauseMenu;
    [field: SerializeField]public bool GameIsActive{get; set;}
    public int CurrentLevel{get; set;}
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
    }
    
    private void Update() 
    {
        SwitchGameState();
    }

    public void StartLevel(int level)
    {
        CurrentLevel = level;
        WaypointManager.instance.SetCurrentPath(level);
        SceneManager.LoadScene(level);
        AuraManager.ClearTowerList();
        GameIsActive = true;
    }
    
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
        GameIsActive = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    //To use correct canvas
    private void SwitchGameState()
    {
        if(GameIsActive)
        {
            gameCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
        }
        else
        {
            gameCanvas.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(true);
        }
    }
}
