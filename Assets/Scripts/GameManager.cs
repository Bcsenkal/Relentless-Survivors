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
    [field: SerializeField]public GameUI GameUI{get; set;}
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
        GameIsActive = false;
    }

    public void StartLevel(int level)
    {
        WaypointManager.instance.SetCurrentPath(level);
        SceneManager.LoadScene(level);
        GameUI.ResetValuesOnNewLevel(level);
        ActivateGameCanvas();
        AuraManager.ClearTowerList();
        GameIsActive = true;
    }
    
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
        ActivateMenuCanvas();
        GameIsActive = false;
    }
}
