using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBeatController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float timeToDestroy = 10f;
    [SerializeField] private GameObject pointPrefab;

    private void OnEnable()
    {
        Invoke(nameof(DestroySelf), timeToDestroy);
    }

    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (Random.value <= 0.3f) Instantiate(pointPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}