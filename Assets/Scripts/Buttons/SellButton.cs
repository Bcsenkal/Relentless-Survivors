using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : ButtonBase
{
    private GameUI gameUI;
    protected override void Awake()
    {
        gameUI = FindObjectOfType<GameUI>();
        GetComponent<Button>().onClick.AddListener(delegate{SellTower();});
        base.Awake();
    }
    
    private void SellTower()
    {
        var currentTower = currentSpot.GetComponent<TowerSpot>().GetCurrentTowerType();
        gameUI.AddCoin(currentTower.GetComponent<Tower>().Price / 2);
        AuraManager.RemoveTower((ITower)currentTower.GetComponent<Tower>());
        Destroy(currentTower);
        
    }
}
