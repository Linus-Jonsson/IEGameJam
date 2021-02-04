
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class EnemySpawner : MonoBehaviour
{
    [Header("every spawn location has its own spawn speed and information")]
    [Header("")]

    [SerializeField] private GameObject prefab;
    public spawn[] spawns;

    #region Singleton
    public static EnemySpawner instance;
    private void Awake() => instance = this;
    #endregion

    private void Update()
    {
        foreach (spawn s in spawns)
        {
            s.timer += Time.deltaTime * s.spawnSpeed;
            if (s.timer >= 1f)
            {
                Instantiate(prefab, s.Location.transform.position, Quaternion.identity);
                if (s.randomSpawnTimer == true)
                {
                    s.spawnSpeed = Random.Range(.1f, 3f);
                }
                s.timer = 0;
            }
        }
        
    }

}

[System.Serializable]
public class spawn
{
    public string name;
    public GameObject Location;
    [Range(.1f, 3)]
    public float spawnSpeed;
    [Space]
    public float timer;
    public bool randomSpawnTimer;
}

//TODO: make the spawner so that every spawnpoint has its own timer where it is modifyed in one component 


