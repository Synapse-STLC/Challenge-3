﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    private Rigidbody asteroid;

    private void Start()
    {
        asteroid = GetComponent<Rigidbody>();

        asteroid.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
