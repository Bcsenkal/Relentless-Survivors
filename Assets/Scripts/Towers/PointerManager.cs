using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerManager : MonoBehaviour
{
    [field: SerializeField]public TowerSelector TowerSelector{get; set;}
    
    void Update()
    {
        if(GameManager.instance.GameIsActive)
        {
           Click(); 
        } 
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
                    TowerSelector.gameObject.SetActive(false);
                    TowerSelector.currentSpot = hit.transform.gameObject;
                    GameObject currentTower = hit.transform.GetComponent<TowerSpot>().GetCurrentTowerType();
                    TowerSelector.RepositionTowerSelector(hit.transform.gameObject);
                    TowerSelector.gameObject.SetActive(true);
                    if(currentTower != null)
                    {
                        TowerSelector.TowerSelectionDecider(currentTower);
                    }
                    else
                    {
                        TowerSelector.DefaultTowerSelection();
                    }
                }
            }
            else
            {
                TowerSelector.gameObject.Clear();
                TowerSelector.gameObject.SetActive(false);
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
