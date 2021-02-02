using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
    [Header("borders")]
    [SerializeField] private float x;
    [SerializeField] private float y;
    [Space]
    [SerializeField] private float spawnSpeed; 
    [SerializeField]private float timer;
    [Header("Amount of enemy")]
    [SerializeField] private int amountOfEnemysSpawned;
    Vector3 panda;

    
    void Update()
    {
        
        timer += Time.deltaTime * spawnSpeed;
        if (timer >= 1f) 
        {
            amountOfEnemysSpawned++;
            panda = new Vector3(transform.position.x + Random.Range(0, x),transform.position.y + Random.Range(0, y));
            Instantiate(PrefabFromArray(prefab), panda ,Quaternion.identity);
            timer = 0;
        }
        Debug.DrawLine(transform.position, panda);
    }

    private GameObject PrefabFromArray(GameObject[] _prefeb)
    {
        int index = Random.Range(0, prefab.Length);
        return _prefeb[index];
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawLine(transform.position,transform.position + Vector3.right * x);    
        Gizmos.DrawLine(transform.position,transform.position + Vector3.up * y);
        Gizmos.DrawWireCube(panda, new Vector3(1, 1, 1));
    }

}
