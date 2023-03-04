using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        Destroy(gameObject);
    }
}
