using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAuraProvider
{
    public string AuraType{get;}
    void ApplyAura(ITower tower);
    void RemoveAura(ITower tower);
}
