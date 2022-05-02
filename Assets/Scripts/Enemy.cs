using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IFlippable
{
    private Vector3[] currentPath;
    private int pathIndex = 0;
    [SerializeField]protected float speed = 10f;
    //Getting reference to waypointmanager on Awake
    void Awake()
    {
        currentPath = WaypointManager.instance.currentPath;
    }
    //Setting starting position as first position of path array
    void Start()
    {
        transform.position = currentPath[pathIndex];
    }

    void Update()
    {
        Move();
        FlipSprite();
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
}
