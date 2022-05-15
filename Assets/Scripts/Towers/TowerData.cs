using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TowerData")]
public class TowerData : ScriptableObject
{
    public Sprite towerSprite;
    public string towerName;
    public int towerPrice;
    public float towerSpeed;
    public int towerDamage;
    public float towerRange;
    public string buffInfo;
    public GameObject towerProjectileType;
    public bool isTowerAuraProvider;
}
