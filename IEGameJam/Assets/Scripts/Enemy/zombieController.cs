using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieController : MonoBehaviour
{
    [SerializeField] private Transform plrTransform;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(plrTransform.position);
    }

    private void OnDrawGizmos()
    {
        
    }
}
