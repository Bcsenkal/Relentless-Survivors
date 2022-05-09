using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    private int currentWave = 0;
    private float spawnInterval = 0.7f;
    private float timeBetweenWaves = 8f;
    private float initialDelay = 3f;
    
    private void Start()
    {
        Invoke("SpawnFirstWave",initialDelay);
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
        if(currentWave < waves.Length -1)
        {
            currentWave ++;
            StartCoroutine(Spawn(waves[currentWave]));
        }
    }
    
    private void SpawnFirstWave()
    {
        StartCoroutine(Spawn(waves[currentWave]));
    }
}
