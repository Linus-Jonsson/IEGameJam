using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<GameObject> spawnPositions;
    [SerializeField] private float spawnDelay;
    [SerializeField] private bool randomSpawnTimer;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(prefab, GetSpawnPosition(spawnPositions).transform.position,Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private GameObject GetSpawnPosition(List<GameObject> _spawnPositions) => _spawnPositions[Random.Range(0, spawnPositions.Count)];

}


