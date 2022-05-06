using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectorButton : ButtonBase
{
    [SerializeField]private GameObject towerPrefab;
    private GameUI gameUI;
    private Tower tower;
    
    protected override void Awake()
    {
        tower = towerPrefab.GetComponent<Tower>();
        gameObject.GetComponent<Button>().onClick.AddListener(delegate {BuildTower();});
        gameUI = FindObjectOfType<GameUI>();
        base.Awake();
    }

    protected override void Update() 
    {
        base.Update();
        PriceCheck();
    }
    //Builds tower and destroys existing if there's one
    private void BuildTower()
    {
        GameObject currentTower = currentSpot.GetComponent<TowerSpot>().GetCurrentTowerType();
        if(currentTower != null)
        {
            Destroy(currentTower);
            AuraManager.RemoveTower((ITower)currentTower.GetComponent<Tower>());
        }
        var buildingTower = Instantiate(towerPrefab,currentSpot.transform.position,Quaternion.identity);
        currentSpot.GetComponent<TowerSpot>().SetCurrentTowerType(buildingTower);
        gameUI.SpendCoin(tower.Price);
        AuraManager.AddTower((ITower)buildingTower.GetComponent<Tower>());
    }
    //Pricecheck for tower purchase
    private void PriceCheck()
    {
        if(gameUI.GetCurrentCoin() >= tower.Price)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
