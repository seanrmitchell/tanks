using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellAttack : MonoBehaviour
{
    public GameObject shellPreFab;

    [SerializeField]
    private Transform firePos;

    [SerializeField]
    private float shellForce;

    public void Shell()
    {
        Debug.Log("Shell!");
        GameObject bolt = Instantiate(shellPreFab, firePos.position, shellPreFab.transform.rotation);
        Rigidbody rb = bolt.GetComponent<Rigidbody>();
        rb.AddForce(firePos.forward * shellForce, ForceMode.Impulse);
    }
}

