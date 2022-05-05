using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class TowerSelector : MonoBehaviour
{
    [SerializeField] public GameObject currentSpot;
    [SerializeField] private float windowOffsetY = 1.5f;
    [SerializeField] private GameObject defaultSelection;
    [SerializeField] private GameObject archerSelection;
    [SerializeField] private GameObject mageSelection;
    [SerializeField] private GameObject acolyteSelection;
    [SerializeField] private GameObject warriorSelection;
    [SerializeField] private GameObject sellButton;
    private void OnEnable() 
    {
        gameObject.Clear();
    }
    public void RepositionTowerSelector(GameObject spot)
    {
        var screenPos = Camera.main.WorldToScreenPoint(new Vector2(spot.transform.position.x,spot.transform.position.y + windowOffsetY));
        transform.position = new Vector2(screenPos.x, (screenPos.y));
    }

    public void CreateTowerSelection(GameObject buttonList)
    {
        buttonList.SetActive(true);
        
    }
    public void TowerSelectionDecider(GameObject tower)
    {
        var name = tower.name.Replace("Tower(Clone)","");
        switch (name)
        {
            case "Archer":
                CreateTowerSelection(archerSelection);
                break;
            case "Mage":
                CreateTowerSelection(mageSelection);
                break;
            case "Warrior":
                CreateTowerSelection(warriorSelection);
                break;
            case "Acolyte":
                CreateTowerSelection(acolyteSelection);
                break;
            default:
                sellButton.gameObject.SetActive(true);
                break;
        }
    }
    public void DefaultTowerSelection()
    {
        CreateTowerSelection(defaultSelection);
    }
}
