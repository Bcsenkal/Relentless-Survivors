using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerSpot : MonoBehaviour
{
    [SerializeField] private GameObject towerType;

    public GameObject GetCurrentTowerType()
    {
        return towerType;
    }
    public void SetCurrentTowerType(GameObject tower)
    {
        towerType = tower;
    }
}
