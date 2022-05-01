using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    public int currentWave = 0;
    private float spawnInterval = 0.3f;
    private float timeBetweenWaves = 5f;
    private void Start() 
    {
       StartCoroutine(Spawn(waves[currentWave]));
    }

    private void Update()
    {

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
}
