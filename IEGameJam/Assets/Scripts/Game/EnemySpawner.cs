
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
            if (s.OnOff == false)
            {
                s.timer += Time.deltaTime * s.spawnSpeed;
                if (s.timer >= 1f)
                {
                    Instantiate(prefab, s.Location.transform.position, Quaternion.identity);
                    if (s.randomSpawnTimer == true)
                    {
                        s.spawnSpeed = UnityEngine.Random.Range(.1f, 3f);
                    }
                    s.timer = 0;
                }
            }
        }
          
    }
    public void TurnOnOrOff(string name, bool OnOff)
    {
        spawn s = Array.Find(spawns, sound => sound.name == name);
        if (s != null)
        {
            Debug.LogError("Sound: " + name + " not found!");
            return;
        }
        s.OnOff = OnOff;
    }
    public void TurnAllOnOrOff(bool OnOff)
    {
        for (int i = 0; i < spawns.Length; i++)
        {
               spawns[i].OnOff = OnOff;
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
    public bool OnOff;
}

//TODO: make the spawner so that every spawnpoint has its own timer where it is modifyed in one component 


