using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameObjectExtensions
{
    static public void Clear(this GameObject gameobject)
    {
        for(int i = gameobject.transform.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(gameobject.transform.GetChild(i).gameObject);
        }
    }
}
