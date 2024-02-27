using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private PlayerUVLight playerUVLight;
    private Vector3 patrolDestination;
    private float currentIdleTime;
    private bool isChasing;
    private float currentTimeUntilChase;
    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> destinations;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float idleTime;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float timeUntilChase;
    [SerializeField] private float uvLightRange;

    //added
    private Animator animator;

    public bool IsChasing
    {
        get => this.isChasing;

        set
        {
            if (value)
            {
                isChasing = true;
                navMeshAgent.speed = chaseSpeed;
            }

            else
            {
                isChasing = false;
                navMeshAgent.speed = patrolSpeed;
            }
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerUVLight = GameObject.Find("UV Light").GetComponent<PlayerUVLight>();
        patrolDestination = GetPatrolDestination();
        navMeshAgent.destination = patrolDestination;
        currentIdleTime = idleTime;
        currentTimeUntilChase = timeUntilChase;
    }

    private void Update()
    {
        if (!IsChasing)
        {
            currentTimeUntilChase -= Time.deltaTime;
        }

        if (currentTimeUntilChase <= 0)
        {
            IsChasing = true;
        }

        if (IsChasing)
        {
            Chase();
        }

        else
        {
            Patrol();
        }
    }

    private Vector3 GetPatrolDestination()
    {
        return destinations[Random.Range(0, destinations.Capacity)].position;
    }

    private bool isStunned()
    {
        Vector3 directionVector = transform.position - player.position;
        Ray ray = new Ray(player.position, directionVector);
        Physics.Raycast(ray, out RaycastHit hit, uvLightRange);
        bool lineOfSight = hit.transform == transform;

        float angle = Vector3.Dot(Camera.main.transform.forward, directionVector);
        bool lookingAt = 0.91f < angle;

        return lineOfSight && lookingAt && playerUVLight.IsUVLightOn;
    }

    private bool AtDestination()
    {
        return patrolDestination.x == transform.position.x && patrolDestination.z == transform.position.z;
    }

    private void Patrol()
    {
       
        if (AtDestination())
        {
            //animate idle
            animator.SetBool("isIdle", true);
            animator.SetBool("isChasing", false);
     

            currentIdleTime -= Time.deltaTime;
            if (currentIdleTime <= 0)
            {
                patrolDestination = GetPatrolDestination();
                navMeshAgent.destination = patrolDestination;
                currentIdleTime = idleTime;
            }
        }

        else
        {
            //animate patrol
            animator.SetBool("isIdle", false);
            animator.SetBool("isChasing", false);
        }
    }

    private void Chase()
    {
        //animate chase
        animator.SetBool("isChasing", true);
        animator.SetBool("isIdle", false);
  

        navMeshAgent.destination = player.position;

        if (isStunned())
        {
            IsChasing = false;
            navMeshAgent.destination = patrolDestination;
            currentTimeUntilChase = timeUntilChase;
        }
    }
}
