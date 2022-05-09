using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IFlippable, ITower
{
    [field: SerializeField]public List<string> CurrentAuras{get; set;}
    [field: SerializeField]public int Price{get; set;}
    [field: SerializeField]public float Speed{get; set;}
    [field: SerializeField]public int Damage{get; set;}
    [field: SerializeField]public float Range{get; set;}
    [field: SerializeField]public GameObject ProjectileType{get; set;}
    [field: SerializeField]public float AttackTimer{get; set;}
    [field: SerializeField]public bool IsAuraProvider{get; set;}
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
