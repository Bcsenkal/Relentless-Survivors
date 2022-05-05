using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField]private int currentCoin;
    [SerializeField]private int maxLife = 10;
    [SerializeField]private TextMeshProUGUI coinText;
    [SerializeField]private GameObject heartContainer;
    [SerializeField]private GameObject heartObject;
    [SerializeField]private TowerSelector towerSelector;
    private void Start() 
    {
        currentCoin = 500;
        UpdateCoinText();
        SetMaxLife();
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
            var container = Instantiate(heartObject);
            container.transform.SetParent(heartContainer.transform);
            container.transform.localScale = new Vector3(1,1,1);
        }
    }
    //Every 5 level gonna be "Hard" level so gives player 10 life instead of 5;
    public void SetMaxLife()
    {
        var currentLevel = (SceneManager.GetActiveScene().buildIndex + 1);
        if(currentLevel % 5 == 0)
        {
            maxLife = 10;
        }
        else
        {
            maxLife = 5;
        }
    }

    public void RemoveLife()
    {
        Destroy(heartContainer.transform.GetChild(heartContainer.transform.childCount -1).gameObject);
    }
    
    public void CheckRemainingLives()
    {
        var nextLives = heartContainer.transform.childCount -1;
        if(nextLives > 0)
        {
            RemoveLife();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void AttachTowerSelector()
    {
        GameObject.Find("PointerManager").GetComponent<PointerManager>().TowerSelector = towerSelector;
    }
}
