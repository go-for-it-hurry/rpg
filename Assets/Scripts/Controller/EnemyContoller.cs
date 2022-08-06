using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterCombat))]
public class EnemyContoller : MonoBehaviour
{
    public float lookRadius = 10f;
    private NavMeshAgent agent;
    private Transform playerTransform;
    private CharacterStats playerStats;
    public float turnSpeed = 5f;
    private CharacterCombat combat;

    private void Start()
    {
        playerTransform = PlayerManager.instance.player.transform;
        playerStats = PlayerManager.instance.playerStats;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(playerTransform.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                combat.Attack(playerStats);
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
