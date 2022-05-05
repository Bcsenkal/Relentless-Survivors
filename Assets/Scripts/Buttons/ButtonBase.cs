using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBase : MonoBehaviour
{
    protected GameObject towerSelector;
    protected GameObject currentSpot;
    [SerializeField]public PointerEventData eventData;
    protected virtual void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(delegate {DisableSelectorOnClick();});
        gameObject.GetComponent<EventTrigger>();
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
        towerSelector = transform.parent.gameObject.transform.parent.gameObject;
        towerSelector.gameObject.SetActive(false);
    }
}
