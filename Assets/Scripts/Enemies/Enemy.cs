using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IFlippable, IDamageable
{
    private Vector3[] currentPath;
    private int pathIndex = 0;
    [Header("Stats")]
    [SerializeField]protected int value;
    [SerializeField]protected float defaultSpeed = 10f;
    protected float currentSpeed;
    [SerializeField]protected float currentHealth;
    [SerializeField]protected float maxHealth;
    [SerializeField]protected float slowDuration;
    private float slowMultiplier = 2f;
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
    //Gets current path info from WaypointManager, healhbar child to visualize damage
    private void Awake()
    {
        currentPath = WaypointManager.instance.currentPath;
        healthBar = transform.GetChild(0).gameObject;
        CurrentHealth = MaxHealth;
        currentSpeed = defaultSpeed;
    }
    //Sets current position to starting point of the path
    private void Start()
    {
        transform.position = currentPath[pathIndex];
    }
    
    private void Update()
    {
        Move();
        FlipSprite();
        SetHealthBar();
        SpeedControl();
    }
    //Move along path waypoints
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,currentPath[pathIndex], currentSpeed * Time.deltaTime);
        if(transform.position == currentPath[pathIndex])
        {
            pathIndex += 1;
        }
        if(pathIndex == currentPath.Length)
        {
            Destroy(gameObject);
        }
    }
    //Sets nextHealth value and calls Death and AddCoin according to nextHealth value
    public void TakeDamage(float damage)
    {
        var nextHealthValue = CurrentHealth - damage;
        if(nextHealthValue <= 0)
        {
            Death();
            UIManager.instance.AddCoin(value);
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
    //Visualizes health amount with color and filling amount
    public void SetHealthBar()
    {
        healthBar.transform.localScale = new Vector3(CurrentHealth/MaxHealth,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
        SetHealthBarColor();
    }
    //Changes healthbar color according to current health percentage
    public void SetHealthBarColor()
    {
        SpriteRenderer renderer = healthBar.GetComponent<SpriteRenderer>();
        if(healthBar.transform.localScale.x < 0.34f)
        {
            renderer.color = Color.red;
        }
        else if(healthBar.transform.localScale.x > 0.67f)
        {
            renderer.color = Color.green;
        }
        else
        {
            renderer.color = new Color(1f,0.4647f,0f,1);
        }
    }
    //Arranges speed
    public void SpeedControl()
    {
        if(slowDuration > 0)
        {
            slowDuration -= Time.deltaTime;
            currentSpeed = defaultSpeed / slowMultiplier;
        }
        else
        {
            currentSpeed = defaultSpeed;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    //Slowing projectiles calls it to slow down enemy
    public void ApplySlowEffect()
    {
        slowDuration = 5f;
        GetComponent<SpriteRenderer>().color = Color.blue;
    }
}