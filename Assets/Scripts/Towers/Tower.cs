using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IFlippable, ITower
{
    [SerializeField]private TowerData towerData;
    [field: SerializeField]public List<string> CurrentAuras{get; set;}
    public int Price{get; set;}
    public float Speed{get; set;}
    public int Damage{get; set;}
    public float Range{get; set;}
    [field: SerializeField]public GameObject ProjectileType{get; set;}
    [field: SerializeField]public float AttackTimer{get; set;}
    public bool IsAuraProvider{get; set;}
    protected GameObject currentTarget;
    protected void OnEnable() {
        GetData();
    }
    protected virtual void Update() 
    {
        FlipSprite();
        Attack();
    }
    //Attacks with interval
    public virtual void Attack()
    {
        AttackTimer += Time.deltaTime;
        if(currentTarget != null && AttackTimer > Speed)
        {
            var projectile = Instantiate(ProjectileType,new Vector2(transform.position.x,transform.position.y + 0.2f),Quaternion.identity,gameObject.transform);
            projectile.GetComponent<Projectile>().TargetToReach = currentTarget;
            projectile.GetComponent<Projectile>().Damage = Damage;
            AttackTimer = 0;
        }
    }
    //Sets current target
    public void SetCurrentTarget(GameObject enemy)
    {
        currentTarget = enemy == null ? null : enemy;
    }
    //Gets current target
    public GameObject GetCurrentTarget()
    {
        return currentTarget;
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position,Range); 
    }
    //Flips sprite to attacking direction
    public void FlipSprite()
    {
        if(currentTarget != null)
        {
            if(currentTarget.transform.position.x > transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    protected void GetData()
    {
        Price = towerData.towerPrice;
        Damage = towerData.towerDamage;
        Range = towerData.towerRange;
        Speed = towerData.towerSpeed;
        ProjectileType = towerData.towerProjectileType;
        IsAuraProvider = towerData.isTowerAuraProvider;
    }
}
