using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : ButtonBase
{
    private UIManager manager;
    protected override void Awake()
    {
        manager = UIManager.instance;
        GetComponent<Button>().onClick.AddListener(delegate{SellTower();});
        base.Awake();
    }
    
    private void SellTower()
    {
        var currentTower = currentSpot.GetComponent<TowerSpot>().GetCurrentTowerType();
        manager.AddCoin(currentTower.GetComponent<Tower>().Price / 2);
        AuraManager.instance.RemoveTower(currentTower);
        Destroy(currentTower.gameObject);
        
    }
}
