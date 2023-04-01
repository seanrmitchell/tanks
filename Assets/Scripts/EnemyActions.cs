using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    [SerializeField]
    private float shellRadius, attackCoolDown;

    private Transform target;

    private float attackSpeed;

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        attackSpeed = attackCoolDown;
    }

    private void Update()
    {
        // Distance from player
        float distance = Vector3.Distance(target.position, transform.position);

        // If player is within range, and shot is not on cooldown, a shot is fired.
        if (distance <= shellRadius && attackSpeed >= attackCoolDown)
        {
            gameObject.GetComponent<ShellAttack>().Shell();
            attackSpeed = 0f;
        }
        else if (attackSpeed < attackCoolDown)
        {
            attackSpeed += Time.deltaTime;
        }
    }
}
