using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField]private int currentCoin;
    [SerializeField]private int maxLife = 10;
    [SerializeField]private int currentLife;
    [SerializeField]private TextMeshProUGUI coinText;
    [SerializeField]private GameObject heartContainer;
    [SerializeField]private TowerSelector towerSelector;

    public void ResetValuesOnNewLevel(int level)
    {
        currentCoin = 500;
        UpdateCoinText();
        SetMaxLife(level);
        CreateStartingLives();
    }

    private void UpdateCoinText()
    {
        coinText.text = currentCoin.ToString();
    }

    public void AddCoin(int value)
    {
        currentCoin += value;
        UpdateCoinText();
    }

    public int GetCurrentCoin()
    {
        return currentCoin;
    }
    
    public void SpendCoin(int value)
    {
        currentCoin -= value;
        UpdateCoinText();
    }
    //Creates life indicators
    public void CreateStartingLives()
    {
        for(int i = 0; i < maxLife; i++)
        {
            heartContainer.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    //Every 5 level gonna be "Hard" level so gives player 12 life instead of 6;
    public void SetMaxLife(int level)
    {
        if(level % 5 == 0)
        {
            maxLife = 12;
        }
        else
        {
            maxLife = 6;
        }
        currentLife = maxLife;
    }

    public void RemoveLife()
    {
        heartContainer.transform.GetChild(currentLife - 1).gameObject.SetActive(false);
        currentLife --;
    }
    
    public void CheckRemainingLives()
    {
        var nextLives = currentLife -1;
        if(nextLives > 0)
        {
            RemoveLife();
        }
        else
        {
            GameManager.instance.ReturnMenu();
        }
    }

    public TowerSelector AttachTowerSelector()
    {
        return towerSelector;
    }
}
