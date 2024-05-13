using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform target; // assign the target in the inspector
    public float minSpeed = 1.0f; // minimum movement speed
    public float maxSpeed = 10.0f; // maximum movement speed
    public float accelerationDistance = 5.0f; // distance over which to accelerate

    private void OnEnable()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        // Calculate the distance to the target
        float distance = Vector3.Distance(transform.position, target.position);

        // Calculate the speed based on the distance
        float speed = Mathf.Lerp(maxSpeed, minSpeed, distance / accelerationDistance);

        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the moving object and the target are approximately equal.
        if (distance < 0.01f)
        {
            // Destroy the gameObject after reaching the target
            Destroy(gameObject);
        }
    }
}