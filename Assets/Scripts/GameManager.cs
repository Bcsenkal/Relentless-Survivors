using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int currentLevel;
    public bool isActive;
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public void StartLevel(int level)
    {
        SetCurrentLevel(level);
        WaypointManager.instance.SetCurrentPath(level);
        SceneManager.LoadScene(level);
        isActive = true;
    }
}
