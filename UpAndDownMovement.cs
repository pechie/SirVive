using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownMovement : MonoBehaviour
{
    public float speed = 3f;
    public float height = 3f;

    void Update()
    {
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, (newY * height), pos.z);
    }
}