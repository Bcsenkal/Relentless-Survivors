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
    private float initialDelay = 1f;

    private void OnEnable()
    {
        if(GameManager.instance.GameIsActive)
        {
            currentWave = 0;
            currentLevelWave = levelWaves[GameManager.instance.CurrentLevel - 1];
            Invoke("SpawnFirstWave",initialDelay);
        }
    }
    //Single coroutine for all waves
    IEnumerator Spawn(Wave wave)
    {
        for(int i = 0; i < wave.enemyPrefabs.Length; i++)
        {
            Instantiate(wave.enemyPrefabs[i]);
            yield return new WaitForSeconds(spawnInterval);
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        SpawnNextWave();
    }

    private void SpawnNextWave()
    {
        if(currentWave < currentLevelWave.waves.Length -1)
        {
            currentWave ++;
            StartCoroutine(Spawn(currentLevelWave.waves[currentWave]));
        }
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
