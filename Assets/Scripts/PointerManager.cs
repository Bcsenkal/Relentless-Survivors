using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerManager : MonoBehaviour
{
    [SerializeField] private TowerSelector towerSelector;
    void Start()
    {
        
    }

    // Update is called once per frame
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
                    towerSelector.currentSpot = hit.transform.gameObject;
                    towerSelector.gameObject.SetActive(true);
                    towerSelector.RepositionTowerSelector(hit.transform.gameObject);
                    if(string.IsNullOrEmpty(hit.transform.GetComponent<TowerSpot>().GetCurrentTowerType()))
                    {
                        towerSelector.DefaultSelection();
                    }
                    else
                    {
                        towerSelector.gameObject.Clear();
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
