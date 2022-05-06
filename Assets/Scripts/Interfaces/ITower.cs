using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITower
{
    public int Price { get;}
    public float Speed { get; set;}
    public int Damage { get;}
    public float Range { get;}
    public GameObject ProjectileType{ get;}
    public float AttackTimer{get;}
    public List<string> CurrentAuras{get; set;}
    public bool IsAuraProvider{get; set;}
    public void Attack();
    public void SetCurrentTarget(GameObject enemy);
    public GameObject GetCurrentTarget();
}
