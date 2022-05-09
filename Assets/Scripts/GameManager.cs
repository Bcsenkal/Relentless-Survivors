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
    public GameUI GameUI
    {
        get{return gameUI;}
    }
    private bool gameIsActive;
    public bool GameIsActive
    {
        get{return gameIsActive;}
        set{gameIsActive = value;}
    }
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
        ActivateMenuCanvas();
    }

    public void ActivateGameCanvas()
    {     
        gameCanvas.gameObject.SetActive(true);
        menuCanvas.gameObject.SetActive(false);
    }
    public void ActivateMenuCanvas()
    {
        menuCanvas.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(false);
    }

    public void StartLevel(int level)
    {
        WaypointManager.instance.SetCurrentPath(level);
        SceneManager.LoadScene(level);
        GameManager.instance.gameUI.ResetValuesOnNewLevel(level);
        GameManager.instance.ActivateGameCanvas();
        AuraManager.ClearTowerList();
    }
    
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
        ActivateMenuCanvas();
    }
}
