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

        float distance = Vector3.Distance(target.position, transform.position);

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
