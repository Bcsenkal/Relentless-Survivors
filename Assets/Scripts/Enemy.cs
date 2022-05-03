using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IFlippable, IDamageable
{
    private Vector3[] currentPath;
    private int pathIndex = 0;
    [Header("Stats")]
    [SerializeField]protected float speed = 10f;
    [SerializeField]protected float currentHealth;
    [SerializeField]protected float maxHealth;
    protected GameObject healthBar;
    public float CurrentHealth
    {
        get{return currentHealth;}
        set{currentHealth = value;}
    }
    public float MaxHealth
    {
        get{return maxHealth;} 
        set{maxHealth = value;}
    }
    void Awake()
    {
        currentPath = WaypointManager.instance.currentPath;
        healthBar = transform.GetChild(0).gameObject;
        CurrentHealth = MaxHealth;
    }

    void Start()
    {
        transform.position = currentPath[pathIndex];
    }

    void Update()
    {
        Move();
        FlipSprite();
        SetHealthBar();
    }
    //Move along path waypoints
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,currentPath[pathIndex], speed * Time.deltaTime);
        if(transform.position == currentPath[pathIndex])
        {
            pathIndex += 1;
        }
        if(pathIndex == currentPath.Length)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        var nextHealthValue = CurrentHealth - damage;
        if(nextHealthValue <= 0)
        {
            Death();
        }
        else
        {
            CurrentHealth = nextHealthValue;
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    //making sprite to trun according to it's current direction
    public void FlipSprite()
    {
        if(pathIndex < currentPath.Length)
        {
            if(currentPath[pathIndex].x > currentPath[pathIndex - 1].x || currentPath[pathIndex].y > currentPath[pathIndex -1].y)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
    public void SetHealthBar()
    {
        healthBar.transform.localScale = new Vector3(CurrentHealth/MaxHealth,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
    }
}
