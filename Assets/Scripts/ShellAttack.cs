using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellAttack : MonoBehaviour
{
    public ArrayList shots = new ArrayList();

    public GameObject shellPreFab;

    [SerializeField]
    private Transform firePos;

    [SerializeField]
    private float shellForce;

    private int count = 0;

    public void Shell()
    {
        Debug.Log("Shell!");

        //Creates shell
        GameObject bolt = Instantiate(shellPreFab, firePos.position, shellPreFab.transform.rotation);
        // Passes the object that fired it to be referenced for available shot to fire
        bolt.GetComponent<Shell>().obj = gameObject;

        // Adds physics
        Rigidbody rb = bolt.GetComponent<Rigidbody>();
        rb.AddForce(firePos.forward * shellForce, ForceMode.Impulse);

        // Passes shell to list of shots
        shots.Add(bolt);
    }
}

