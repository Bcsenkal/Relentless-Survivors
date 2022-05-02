using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IFlippable
{
    
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    [SerializeField] protected int range;
    public int Range
    {
        get{return range;}
        set{range = value;}
    }
    [SerializeField] protected GameObject projectileType;
    [SerializeField] protected float attackTimer;
    protected GameObject currentTarget;
    private void Awake() 
    {
        
    }
    private void Update() 
    {
        FlipSprite();
        Attack();
    }
    protected virtual void Attack()
    {
        attackTimer += Time.deltaTime;
        if(currentTarget != null && attackTimer > speed)
        {
            var projectile = Instantiate(projectileType,new Vector2(transform.position.x,transform.position.y + 1),Quaternion.identity,gameObject.transform);
            attackTimer = 0;
        }
    }

    public void SetCurrentTarget(GameObject enemy)
    {
        currentTarget = enemy == null ? null : enemy;
    }
    public GameObject GetCurrentTarget()
    {
        return currentTarget;
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position,range); 
    }
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
        
    }
}
