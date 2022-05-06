using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraTower : Tower, IAuraProvider
{
    public virtual void ApplyAura(GameObject tower)
    {
        tower.GetComponent<Tower>().currentAuras.Add(gameObject.name);
    }
    public virtual void RemoveAura(GameObject tower)
    {
        tower.GetComponent<Tower>().currentAuras.Remove(gameObject.name);
    }
}
