using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This static class holds the data of enemies on the scene. I thought it is a better approach to check "FindObjectsOfType" in Update.
//So we simply store enemies in a list and create win condition properly.
public static class LivingEnemies
{
    public static List<IDamageable> enemiesAlive;
    public static bool isSpawning;

    static LivingEnemies()
    {
        enemiesAlive = new List<IDamageable>();
        isSpawning = false;
    }

    public static void AddEnemy(GameObject enemy)
    {
        enemiesAlive.Add((IDamageable)enemy.GetComponent<Enemy>());
    }

    public static void RemoveEnemy(GameObject enemy)
    {
        enemiesAlive.Remove((IDamageable)enemy.GetComponent<Enemy>());
        Debug.Log(enemiesAlive.Count);
        Debug.Log(isSpawning);
        if(GetCurrentEnemyCount() == 0 && !isSpawning)
        {
            GameManager.instance.gameUI.CallWinCondition();
        }
    }

    public static int GetCurrentEnemyCount()
    {
        return enemiesAlive.Count;
    }

    public static void ClearEnemyList()
    {
        enemiesAlive.Clear();
    }
}
