using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IFlippable
{
    [SerializeField] public List<string> currentAuras;
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
    [SerializeField] protected float attackTimer;
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
    protected virtual void Attack()
    {
        attackTimer += Time.deltaTime;
        if(currentTarget != null && attackTimer > speed)
        {
            var projectile = Instantiate(projectileType,new Vector2(transform.position.x,transform.position.y + 0.2f),Quaternion.identity,gameObject.transform);
            projectile.GetComponent<Projectile>().TargetToReach = currentTarget;
            projectile.GetComponent<Projectile>().Damage = Damage;
            attackTimer = 0;
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
        Gizmos.DrawWireSphere(transform.position,range); 
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
