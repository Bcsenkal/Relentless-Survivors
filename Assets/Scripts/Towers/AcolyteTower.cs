using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcolyteTower : Tower, IBuildable
{
    public int price{get; set;}

    protected override void Attack()
    {
        attackTimer += Time.deltaTime;
        if(currentTarget != null && attackTimer > speed)
        {
            var projectile = Instantiate(projectileType,new Vector2(transform.position.x,transform.position.y + 1),Quaternion.identity,gameObject.transform);
            attackTimer = 0;
        }
    }
}
