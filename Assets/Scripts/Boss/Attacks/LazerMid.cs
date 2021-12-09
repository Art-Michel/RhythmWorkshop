using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class LazerMid : MonoBehaviour
{
    [SerializeField] Pool pool;
    Vector3 spawnPoint;

    GameObject LAZERBoss;

    [SerializeField]
    int numberOfProjectiles;

    Vector2 startPoint;
    float angle = 0f;

    void SpawnBullet()
    {
        LAZERBoss = pool.Get();
        LAZERBoss.SetActive(true);
        LAZERBoss.transform.position = spawnPoint;
        LAZERBoss.transform.rotation=Quaternion.Euler(0,0,angle);
        LAZERBoss.GetComponent<LAZER>().Spawn(pool);
    }

    [Button]
    void SpawnProjectiles()
    {
        spawnPoint = transform.position;
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {
            SpawnBullet();
            angle += angleStep;
            Debug.Log("angle="+angle);
        }
    }
}
