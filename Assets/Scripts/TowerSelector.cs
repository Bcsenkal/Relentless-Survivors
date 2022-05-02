using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class TowerSelector : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;
    [SerializeField] public GameObject currentSpot;
    [SerializeField] private float windowOffsetY = 1.5f;
    

    public void RepositionTowerSelector(GameObject spot)
    {
        var screenPos = Camera.main.WorldToScreenPoint(new Vector2(spot.transform.position.x,spot.transform.position.y + windowOffsetY));
        transform.position = new Vector2(screenPos.x, (screenPos.y + 2f));
    }
    public void DefaultSelection()
    {
        if(gameObject.transform.childCount == 0)
        {
            for(int i = 0; i < buttons.Count; i++)
            {
                var currentButton = Instantiate(buttons[i]);
                currentButton.onClick.AddListener(delegate{currentSpot.GetComponent<TowerSpot>().BuildTower(currentButton.name);});
                currentButton.transform.SetParent(this.gameObject.transform);
            }
        }
    }

    private void ClearTowerSelection()
    {
        transform.gameObject.Clear();
    }
}
