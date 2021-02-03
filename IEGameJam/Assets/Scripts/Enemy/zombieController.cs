using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieController : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private NavMeshAgent agent;
    private float distance;
    private Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        agent.SetDestination(destination.position);
        distance = Vector2.Distance(transform.position, destination.position);
        if (distance <= 2.2f)
        {
            animator.SetBool("isInRadius", true);
            hit();
        }
    }

    IEnumerator hit()
    {
        yield return new WaitForSeconds(0.5f);
        
    }
    private void OnDrawGizmos()
    {
        
    }
}
