using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelectorButton : ButtonBase
{
    [SerializeField]private GameObject towerPrefab;
    private UIManager manager;
    private Tower tower;
    protected override void Awake()
    {
        tower = towerPrefab.GetComponent<Tower>();
        gameObject.GetComponent<Button>().onClick.AddListener(delegate {BuildTower();});
        manager = UIManager.instance;
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
        var currentTower = currentSpot.GetComponent<TowerSpot>().GetCurrentTowerType();
        if(currentTower != null)
        {
            Destroy(currentTower);
            AuraManager.instance.RemoveTower(currentTower);
        }
        var buildingTower = Instantiate(towerPrefab,currentSpot.transform.position,Quaternion.identity);
        currentSpot.GetComponent<TowerSpot>().SetCurrentTowerType(buildingTower);
        manager.SpendCoin(tower.Price);
        AuraManager.instance.AddTower(buildingTower);
    }
    //Pricecheck for tower purchase
    private void PriceCheck()
    {
        if(manager.GetCurrentCoin() >= tower.Price)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
