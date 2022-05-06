using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IFlippable, ITower
{
    [SerializeField] protected List<string> currentAuras;
    public List<string> CurrentAuras
    {
        get{return currentAuras;}
        set{currentAuras = value;}
    }
    [SerializeField] protected int price;
    public int Price
    {
        get{return price;}
    }
    [SerializeField] protected float speed;
    public float Speed
    {
        get{return speed;}
        set{speed = value;}
    }
    [SerializeField] protected int damage;
    public int Damage
    {
        get{return damage;}
    }
    [SerializeField] protected float range;
    public float Range
    {
        get{return range;}
        set{range = value;}
    }
    [SerializeField] protected GameObject projectileType;
    public GameObject ProjectileType
    {
        get{return projectileType;}
    }
    [SerializeField] protected float attackTimer;
    public float AttackTimer
    {
        get{return attackTimer;}
        set{attackTimer = value;}
    }
    [SerializeField] protected bool isAuraProvider;
    public bool IsAuraProvider
    {
        get{return isAuraProvider;}
        set{isAuraProvider = value;}
    }
    protected float auraSpeedMultiplier = 1.4f;
    protected GameObject currentTarget;
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
}
