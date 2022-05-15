using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<LevelWaves> levelWaves;
    private LevelWaves currentLevelWave;
    private int currentWave = 0;
    private float spawnInterval = 0.7f;
    private float timeBetweenWaves = 8f;
    private float initialDelay = 3f;

    private void OnEnable()
    {
        if(GameManager.instance.GameIsActive)
        {
            currentWave = 0;
            LivingEnemies.isSpawning = true;
            currentLevelWave = levelWaves[GameManager.instance.CurrentLevel - 1];
            Invoke("SpawnFirstWave",initialDelay);
        }
    }
    
    //Single coroutine for all waves
    IEnumerator Spawn(Wave wave)
    {
        for(int i = 0; i < wave.enemyPrefabs.Length; i++)
        {
            var enemy = Instantiate(wave.enemyPrefabs[i]);
            LivingEnemies.AddEnemy(enemy);
            yield return new WaitForSeconds(spawnInterval);
        }
        if(currentWave < currentLevelWave.waves.Length -1)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnNextWave();
        }
        else
        {
            LivingEnemies.isSpawning = false;
        }
    }

    private void SpawnNextWave()
    {
        currentWave ++;
        StartCoroutine(Spawn(currentLevelWave.waves[currentWave]));
    }
    
    private void SpawnFirstWave()
    {
        StartCoroutine(Spawn(currentLevelWave.waves[currentWave]));
    }
    //Stops coroutines and Invoke to avoid errors.
    private void OnDisable() 
    {
        StopAllCoroutines();
        CancelInvoke("SpawnFirstWave");
    }
}
