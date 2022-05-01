using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int currentLevel;
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

    private void SetCurrentLevel(int stage)
    {
        currentLevel = stage;
    }

    public void StartLevel(int stage)
    {
        SetCurrentLevel(stage);
        SceneManager.LoadScene(stage);
    }
}
