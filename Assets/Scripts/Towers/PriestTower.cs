using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestTower : AuraTower, IAuraProvider
{
    [SerializeField] private float speedMultiplier;

    public override void ApplyAura(ITower tower)
    {
        tower.Speed /= speedMultiplier;
        base.ApplyAura(tower);
    }
    
    public override void RemoveAura(ITower tower)
    {
        tower.Speed *= speedMultiplier;
        base.RemoveAura(tower);
    }
}
