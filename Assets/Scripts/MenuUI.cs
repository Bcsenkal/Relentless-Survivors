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
}
