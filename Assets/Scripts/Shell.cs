using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Shell : MonoBehaviour
{
    public GameObject collExplode;
    public AudioSource boom;

    public GameObject obj;

    [SerializeField] private int numOfBounces;

    private Rigidbody rb;

    private Vector3 lastVelo;
    private float curSpeed;
    private Vector3 direction;
    private int curBounces = 0;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        lastVelo = rb.velocity;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (curBounces < numOfBounces && !(col.collider.gameObject.layer == 3))
        {
            // magnitude of velocity = speed
            curSpeed = lastVelo.magnitude;

            // Creates new vector based on contact w/ plane producing normal vector of their cross product
            direction = Vector3.Reflect(lastVelo.normalized, col.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(curSpeed, 0);

            curBounces++;
        }
        else if(col.collider.gameObject.layer == 3)
        {
            col.collider.gameObject.GetComponent<Health>().UpdateHealth(1);
            // Passes explosion particle effect as well as sound effects.
            GameObject explosion = (GameObject)Instantiate(
                collExplode, transform.position, transform.rotation);
            Destroy(explosion, 4f);

            // Destroys shell and removes it from the referenced objects list of shots
            obj.GetComponent<ShellAttack>().shots.Remove(gameObject);
            Destroy(gameObject);
        }
        else
        {
            // Passes explosion particle effect as well as sound effects.
            GameObject explosion = (GameObject)Instantiate(
                collExplode, transform.position, transform.rotation);
            Destroy(explosion, 4f);

            // Destroys shell and removes it from the referenced objects list of shots
            obj.GetComponent<ShellAttack>().shots.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
