using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour
{
    protected GameObject towerSelector;
    protected GameObject currentSpot;
    protected virtual void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate {DisableSelectorOnClick();});
    }

    protected virtual void Update()
    {
        GetCurrentSpot();
    }

    void GetCurrentSpot()
    {
        currentSpot = GetComponentInParent<TowerSelector>().currentSpot;
    }
    
    void DisableSelectorOnClick()
    {
        towerSelector = transform.parent.gameObject;
        towerSelector.gameObject.SetActive(false);
    }
}
