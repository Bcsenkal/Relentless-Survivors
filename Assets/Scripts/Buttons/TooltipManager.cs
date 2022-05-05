using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class TooltipManager : MonoBehaviour
{
    [SerializeField] private GameObject tooltip;
    [SerializeField] private Image tooltipTowerImage;
    [SerializeField] private TextMeshProUGUI tooltipNameText;
    [SerializeField] private TextMeshProUGUI tooltipDamageText;
    [SerializeField] private TextMeshProUGUI tooltipSpeedText;
    [SerializeField] private TextMeshProUGUI tooltipPriceText;
    [SerializeField] private TextMeshProUGUI tooltipRangeText;
    [SerializeField] private TextMeshProUGUI tooltipBuffInfoText;
    [SerializeField] private Vector3 offset;
    public void ShowTooltip(TowerData button)
    {
        tooltip.gameObject.SetActive(true);
        tooltipTowerImage.sprite = button.towerSprite;
        tooltipNameText.text = button.towerName + " Tower";
        tooltipDamageText.text = button.towerDamage.ToString();
        tooltipSpeedText.text = button.towerSpeed.ToString();
        tooltipPriceText.text = button.towerPrice.ToString();
        tooltipRangeText.text = button.towerRange.ToString();
        tooltipBuffInfoText.text = button.buffInfo;
    }
    public void HideTooltip()
    {
        tooltip.gameObject.SetActive(false);
    }
}

