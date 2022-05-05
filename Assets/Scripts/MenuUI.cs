using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] public int currentLevel;
    private void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public void StartLevel(int level)
    {
        SetCurrentLevel(level);
        WaypointManager.instance.SetCurrentPath(level);
        SceneManager.LoadScene(level);
        GameManager.instance.ActivateGameCanvas();
        AuraManager.ClearTowerList();
    }
}
