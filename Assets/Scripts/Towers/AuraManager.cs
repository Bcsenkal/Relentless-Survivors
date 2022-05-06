using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class AuraManager
{
    public static List<ITower> towerList;
    public static List<IAuraProvider> auraTowerList;
    static AuraManager()
    {
        towerList = new List<ITower>();
        auraTowerList = new List<IAuraProvider>();
    }
    //clears towerlist on awake for new levels
    //Adds tower
    public static void AddTower(ITower tower)
    {
        towerList.Add(tower);
        Debug.Log(towerList.Count());
        Debug.Log(auraTowerList.Count());
        ApplyAurasToNewTower(tower);
        if(tower.IsAuraProvider)
        {
            AddAuraTower((IAuraProvider)tower);
            
        }
    }
    //Removes tower
    public static void RemoveTower(ITower tower)
    {
        towerList.Remove(tower);
        if(tower.IsAuraProvider)
        {
            RemoveAuraIfNoneExists((IAuraProvider)tower);
            auraTowerList.Remove((IAuraProvider)tower);
        }
    }
    //Applies current auras to newly created tower, only once.
    private static void ApplyAurasToNewTower(ITower tower)
    {
        if(auraTowerList.Count() > 0)
        {
            for(int i = 0; i < auraTowerList.Count(); i++)
            {
                auraTowerList[i].ApplyAura(tower);
            }
        }
    }
    //Applies Aura Tower's aura to existing towers, only once.
    private static void ApplyAuraToExistingTowers(IAuraProvider tower)
    {
        if(auraTowerList.Count() > 0)
        {
            for(int i = 0; i < towerList.Count(); i++)
            {
                tower.ApplyAura(towerList[i]);
            }
        }
        
    }
    //Checks if it's the last aura tower of the same type
    private static void RemoveAuraIfNoneExists(IAuraProvider tower)
    {
        if(!auraTowerList.Contains(tower))
        {
            for(int i = 0; i < towerList.Count(); i++)
            {
                tower.RemoveAura(towerList[i]);
            }
        }
    }
    public static void ClearTowerList()
    {
        towerList.Clear();
        auraTowerList.Clear();
    }
    public static void AddAuraTower(IAuraProvider auraTower)
    {
        if((auraTowerList.Where(t => t.AuraType == auraTower.AuraType).Count() == 0))
        {
            auraTowerList.Add(auraTower);
            ApplyAuraToExistingTowers(auraTower);
        }
    }
}
