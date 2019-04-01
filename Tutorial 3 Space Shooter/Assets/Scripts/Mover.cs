using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody bolt;

    void Start()
    {
        bolt = GetComponent<Rigidbody>();
        bolt.velocity = transform.forward * speed;
    }
}
