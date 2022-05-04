using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAuraProvider
{
    void ApplyAura(GameObject tower);
    void RemoveAura(GameObject tower);
}
