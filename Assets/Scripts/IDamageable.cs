using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float CurrentHealth{get; set;}
    float MaxHealth{get; set;}

    void TakeDamage(float damage);
    void Death();
}
