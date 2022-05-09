using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraTower : Tower, IAuraProvider
{
    [field: SerializeField]public string AuraType{get; set;}
    public virtual void ApplyAura(ITower tower)
    {
        tower.CurrentAuras.Add(gameObject.name);
    }
    
    public virtual void RemoveAura(ITower tower)
    {
        tower.CurrentAuras.Remove(gameObject.name);
    }
}
