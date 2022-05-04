using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(other.gameObject);
            UIManager.instance.CheckRemainingLives();
        }
    }
}
