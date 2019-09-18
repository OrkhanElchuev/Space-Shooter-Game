using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    private int startWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[startWave];
        StartCoroutine(SpawnAllEnemies(currentWave));
    }

    // For spawning enemies in current wave
    private IEnumerator SpawnAllEnemies(WaveConfig waveConfig)
    {
        // i corresponds to enemy count
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            // Creating enemies and spawning after specified delay
            Instantiate(waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());

        }
    }
}
