using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.ObjectModel;

public class AuraManager : MonoBehaviour
{
    public List<GameObject> towerList;
    public List<string> towerNames;
    public static AuraManager instance;
    //clears towerlist on awake for new levels
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        towerList.Clear();
    }
    //Adds tower
    public void AddTower(GameObject tower)
    {
        towerList.Add(tower);
        ApplyAuraToNewTower(tower);
        if(tower.GetComponent<Tower>().IsAuraProvider)
        {
            ApplyAuraToExistingTowers(tower);
        }
    }
    //Removes tower
    public void RemoveTower(GameObject tower)
    {
        towerList.Remove(tower);
        if(tower.GetComponent<Tower>().IsAuraProvider)
        {
            RemoveAuraIfNoneExists(tower);
        }
    }
    //Applies current auras to newly created tower, only once.
    public void ApplyAuraToNewTower(GameObject tower)
    {
        var currentAuraTowers = towerList.Where(t => t.GetComponent<AuraTower>()).ToArray();
        if(currentAuraTowers.Count() > 0)
        {
            for(int i = 0; i < currentAuraTowers.Count(); i++)
            {
                if(!tower.GetComponent<Tower>().currentAuras.Contains(currentAuraTowers[i].name))
                {
                    currentAuraTowers[i].GetComponent<AuraTower>().ApplyAura(tower);
                    tower.GetComponent<Tower>().currentAuras.Add(currentAuraTowers[i].name);
                    break;
                }
            }
        }
    }
    //Applies Aura Tower's aura to existing towers, only once.
    public void ApplyAuraToExistingTowers(GameObject tower)
    {
        for(int i = 0; i < towerList.Count(); i++)
        {
            if(!towerList[i].GetComponent<Tower>().currentAuras.Contains(tower.name))
            {
                tower.GetComponent<AuraTower>().ApplyAura(towerList[i]);
                towerList[i].GetComponent<Tower>().currentAuras.Add(tower.name);
            }
        }
    }
    //Checks if it's the last aura tower of the same type
    private void RemoveAuraIfNoneExists(GameObject tower)
    {
        var activeTowers = towerList.Where(t => t.name == tower.name).ToArray();
        if(activeTowers.Count() == 0)
        {
            for(int i = 0; i < towerList.Count(); i++)
            {
                tower.GetComponent<AuraTower>().RemoveAura(towerList[i]);
                towerList[i].GetComponent<Tower>().currentAuras.Remove(tower.name);
            }
        }
    }
}
