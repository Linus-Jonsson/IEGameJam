using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieController : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    private NavMeshAgent agent;
    private float distance;
    private Animator animator;
    private GameLoopController gameLoopController;
    private Vector3 datePos;
    private Vector3 plrPos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        destination = GameObject.Find("Plr").transform.position;
        gameLoopController = FindObjectOfType<GameLoopController>();
        datePos = GameObject.Find("Date").transform.position;
        plrPos = GameObject.Find("Plr").transform.position;
        destination = SetDestination();
    }

    void Update()
    {
        agent.SetDestination(destination);
        distance = Vector3.Distance(transform.position, destination);
        if (distance <= 2.2f){
            animator.SetBool("isInRadius", true);

            if (destination == datePos)
                StartCoroutine(Hit(true));
            else StartCoroutine(Hit(false));
        }
        
    }

    private Vector3 SetDestination()
    {
        float distanceToDate = Vector3.Distance(gameObject.transform.position, datePos);
        float distanceToPlr = Vector3.Distance(gameObject.transform.position, plrPos);
        Vector3 des;
        if (distanceToDate > distanceToPlr)
            des = plrPos;
        else
            des = datePos;
        return des;
    }

    IEnumerator Hit(bool hitDate)
    {
        yield return new WaitForSeconds(2f);
        if (hitDate) gameLoopController.HandleLoseState();
        else gameLoopController.HandleDeathState();
    }
}
