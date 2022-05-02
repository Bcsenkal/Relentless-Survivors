using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Tower tower;
    private GameObject targetToReach;
    [SerializeField]private float speed = 3f;
    [SerializeField]private float projectileLifetime;
    private float lifetimeTimer;
    void Awake()
    {
        tower = GetComponentInParent<Tower>();
        targetToReach = tower.GetCurrentTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(targetToReach)
        {
            ReachTarget();
        }
        else if(!targetToReach)
        {
            Destroy(gameObject);
        }
        Lifetime();
    }
    private void ReachTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position,targetToReach.transform.position,speed * Time.deltaTime); 
        transform.up = targetToReach.transform.position - transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject == targetToReach)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
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
