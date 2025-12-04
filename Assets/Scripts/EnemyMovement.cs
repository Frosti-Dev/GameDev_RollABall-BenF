using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    [Header("Speeds")]
    public float defaultSpeed = 3f;
    public float slowedSpeed = 1f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent != null )
        {
            navMeshAgent.speed = defaultSpeed;
        }
    }

    public void ApplyLightEffect()
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.speed = slowedSpeed;
        }
    }

    public void RemoveLightEffect()
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.speed = defaultSpeed;
        }
    }

    void Update()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }
}
