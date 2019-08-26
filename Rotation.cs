﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 200f;

    void Update()
    {
        transform.Rotate(0, 0, (-rotationSpeed * Time.deltaTime));
    }
}