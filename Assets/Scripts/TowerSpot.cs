using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerSpot : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerPrefabs;
    [SerializeField] private string towerType;
    [SerializeField] private bool hasTower;

    public void BuildTower(string name)
    {
        if(!hasTower)
        {
            Instantiate(towerPrefabs.Single(t => t.name == name.Replace("(Clone)","") + "Tower"),new Vector2(transform.position.x,transform.position.y),Quaternion.identity);
            towerType = name.Replace("(Clone)","");
            hasTower = true;
        }
    }

    public string GetCurrentTowerType()
    {
        return towerType;
    }
}
