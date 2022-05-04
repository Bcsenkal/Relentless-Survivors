using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class TowerSelector : MonoBehaviour
{
    [SerializeField] private List<Button> defaultTowerButtons;
    [SerializeField] private List<Button> archerTowerUpgradeButtons;
    [SerializeField] private List<Button> mageTowerUpgradeButtons;
    [SerializeField] private List<Button> warriorTowerUpgradeButtons;
    [SerializeField] private List<Button> acolyteTowerUpgradeButtons;
    [SerializeField] private Button sellButton;
    [SerializeField] public GameObject currentSpot;
    [SerializeField] private float windowOffsetY = 1.5f;

    private void OnEnable() 
    {
        gameObject.Clear();
        Debug.Log("enabled");
    }
    public void RepositionTowerSelector(GameObject spot)
    {
        var screenPos = Camera.main.WorldToScreenPoint(new Vector2(spot.transform.position.x,spot.transform.position.y + windowOffsetY));
        transform.position = new Vector2(screenPos.x, (screenPos.y + 2f));
    }

    public void CreateTowerSelection(List<Button> buttonList)
    {
        for(int i = 0; i < buttonList.Count; i++)
        {
            CreateButton(buttonList[i]);
        }
        if(currentSpot.GetComponent<TowerSpot>().GetCurrentTowerType() != null)
        {
            CreateButton(sellButton);
        }
    }
    public void TowerSelectionDecider(GameObject tower)
    {
        var name = tower.name.Replace("Tower(Clone)","");
        switch (name)
        {
            case "Archer":
                CreateTowerSelection(archerTowerUpgradeButtons);
                break;
            case "Mage":
                CreateTowerSelection(mageTowerUpgradeButtons);
                break;
            case "Warrior":
                CreateTowerSelection(warriorTowerUpgradeButtons);
                break;
            case "Acolyte":
                CreateTowerSelection(acolyteTowerUpgradeButtons);
                break;
            default:
                CreateButton(sellButton);
                break;
        }
    }
    public void DefaultTowerSelection()
    {
        CreateTowerSelection(defaultTowerButtons);
    }
    public void CreateButton(Button button)
    {
        var currentButton = Instantiate(button);
        currentButton.transform.SetParent(this.gameObject.transform);
    }
}
