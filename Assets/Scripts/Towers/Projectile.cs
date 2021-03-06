using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Tower tower;
    public GameObject TargetToReach{get; set;}
    [SerializeField]private float speed = 3f;
    public int Damage{get; set;}
    [SerializeField]private float projectileLifetime;
    [SerializeField]private bool canSlow;
    private float lifetimeTimer;
    // Update is called once per frame
    void Update()
    {
        if(TargetToReach)
        {
            ReachTarget();
        }
        else if(!TargetToReach)
        {
            Destroy(gameObject);
        }
        Lifetime();
    }
    private void ReachTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position,TargetToReach.transform.position,speed * Time.deltaTime); 
        transform.up = TargetToReach.transform.position - transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject == TargetToReach)
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
            if(canSlow)
            {
                other.gameObject.GetComponent<Enemy>().ApplySlowEffect();
            }
            Destroy(gameObject);
        }
    }
    private void Lifetime()
    {
        lifetimeTimer += Time.deltaTime;
        if(lifetimeTimer > projectileLifetime)
        {
            Destroy(gameObject);
        }
    }
}
