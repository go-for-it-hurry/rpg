using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContoller : MonoBehaviour
{
    public float lookRadius = 10f;
    private NavMeshAgent agent;
    private Transform targetTransform;
    public float turnSpeed = 5f;

    private void Start()
    {
        targetTransform = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, targetTransform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(targetTransform.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
