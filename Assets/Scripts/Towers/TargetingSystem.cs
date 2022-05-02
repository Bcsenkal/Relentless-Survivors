using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetingSystem : MonoBehaviour
{
    private int range;
    private Tower tower;
    public GameObject currentTarget;
    private void Awake()
    {
        tower = GetComponent<Tower>();
        range = tower.Range;
    }

    void Update()
    {
        GetTarget();
        CheckIfTargetInRange();
        tower.SetCurrentTarget(currentTarget);
    }

    private void GetTarget()
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position,range);
        if(currentTarget == null)
        {
            foreach(Collider2D collider2D in colliderArray)
            {
                if(collider2D.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    currentTarget = collider2D.gameObject;
                    break;
                }
            }
        }
    }
    
    private void CheckIfTargetInRange()
    {
        if(currentTarget != null)
        {
            if(Vector2.Distance(transform.position,currentTarget.transform.position) > range)
            {
                currentTarget = null;
            }
        }
    }
}
