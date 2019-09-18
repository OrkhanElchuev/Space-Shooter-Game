using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startWave = 0;
    [SerializeField] bool enemyLooping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (enemyLooping);
    }

    // For spawning all waves
    private IEnumerator SpawnAllWaves()
    {
        // i corresponds to wave index
        for(int i = startWave; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemies(currentWave));
        }
    }

    // For spawning enemies in current wave
    private IEnumerator SpawnAllEnemies(WaveConfig waveConfig)
    {
        // i corresponds to enemy count
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            // Creating enemies and spawning after specified delay
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());

        }
    }
}
