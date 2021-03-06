using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        transform.position = transform.parent.position;
        PlayDeathAnimation();
    }
    
    public void PlayDeathAnimation()
    {
        gameObject.transform.SetParent(null);
        animator.Play("DeathAnimation");
        Destroy(gameObject,0.3f);
    }
}
