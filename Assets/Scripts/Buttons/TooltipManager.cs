using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] private GameObject tooltip;
    [SerializeField] private Canvas canvas;
    public void ShowTooltip(GameObject button)
    {
        tooltip.gameObject.SetActive(true);
    }
    public void HideTooltip()
    {
        tooltip.gameObject.SetActive(false);
    }
}
