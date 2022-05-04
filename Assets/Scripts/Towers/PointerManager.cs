using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerManager : MonoBehaviour
{
    [SerializeField] private TowerSelector towerSelector;
    
    void Update()
    {
        Click();
        
    }
    private void Click()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit = GetRaycastHit();
            if(hit)
            {
                if(hit.transform.tag == "TowerSpot")
                {
                    towerSelector.gameObject.SetActive(false);
                    Debug.Log("deactivated");
                    towerSelector.currentSpot = hit.transform.gameObject;
                    GameObject currentTower = hit.transform.GetComponent<TowerSpot>().GetCurrentTowerType();
                    towerSelector.RepositionTowerSelector(hit.transform.gameObject);
                    towerSelector.gameObject.SetActive(true);
                    Debug.Log("Activated");
                    if(currentTower != null)
                    {
                        towerSelector.TowerSelectionDecider(currentTower);
                    }
                    else
                    {
                        towerSelector.DefaultTowerSelection();
                    }
                }
            }
            else
            {
                towerSelector.gameObject.Clear();
                towerSelector.gameObject.SetActive(false);
            }
        }
    }
    private RaycastHit2D GetRaycastHit()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x,mousePos.y);
        return Physics2D.Raycast(mousePos2D,Vector2.zero);
    }
}