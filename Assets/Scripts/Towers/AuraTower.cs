using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraTower : Tower, IAuraProvider
{
    [SerializeField]protected string auraType;
    public string AuraType
    {
        get{return auraType;}
        set{auraType = value;}
    }

    public virtual void ApplyAura(ITower tower)
    {
        tower.CurrentAuras.Add(gameObject.name);
    }
    
    public virtual void RemoveAura(ITower tower)
    {
        tower.CurrentAuras.Remove(gameObject.name);
    }
}
