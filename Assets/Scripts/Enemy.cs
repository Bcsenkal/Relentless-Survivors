using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private WaypointManager waypointManager;
    private Vector3[] currentPath;
    private int pathIndex = 0;
    protected float speed = 10f;
    void Awake()
    {
        waypointManager = FindObjectOfType<WaypointManager>();
    }
    void OnEnable()
    {
        currentPath = waypointManager.GetCurrentStagePath(GameManager.instance.currentLevel);
    }
    void Start()
    {
        transform.position = currentPath[pathIndex];
    }

    void Update()
    {
        Move();
        FlipSprite();
    }

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

    private void FlipSprite()
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
}
