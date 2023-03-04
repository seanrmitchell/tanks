using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent enemy;

    [SerializeField]
    private float lookRadius;

    private Transform target;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        // Euclidean distance between enemy and target
        float distance = Vector3.Distance(target.position, transform.position);

        //If player distance is less than lookRadius move towards them, otherwise stopped
        if (distance <= lookRadius)
        {
            enemy.isStopped = false;

            enemy.SetDestination(target.position);

            if (distance <= enemy.stoppingDistance)
                FacePlayer();

        } else
        {
            enemy.isStopped = true;
        }
    }

    void OnGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    // Takes vector of target and enemy pos, and turns enemy to face target
    void FacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(target.position.x, 0f, target.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }
}
