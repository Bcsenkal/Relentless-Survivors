using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBase : MonoBehaviour
{
    protected GameObject towerSelector;
    protected GameObject currentSpot;
    
    protected virtual void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate {DisableSelectorOnClick();});
        towerSelector = transform.parent.parent.gameObject;
    }

    protected virtual void Update()
    {
        GetCurrentSpot();
    }

    void GetCurrentSpot()
    {
        currentSpot = towerSelector.GetComponent<TowerSelector>().currentSpot;
    }
    
    void DisableSelectorOnClick()
    {
        towerSelector.gameObject.SetActive(false);
    }
}
