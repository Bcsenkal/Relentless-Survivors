using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestTower : AuraTower, IAuraProvider
{
    [SerializeField] private float speedMultiplier;

    public override void ApplyAura(GameObject tower)
    {
        tower.GetComponent<Tower>().Speed /= speedMultiplier;
    }
    
    public override void RemoveAura(GameObject tower)
    {
        tower.GetComponent<Tower>().Speed *= speedMultiplier;
    }
}
