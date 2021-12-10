using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class LazerMid : MonoBehaviour
{
    [SerializeField] Pool pool;
    Vector3 spawnPoint;

    GameObject LAZERBoss;
    List<GameObject> lazerList = new List<GameObject>();

    [SerializeField]
    int numberOfProjectiles;

    Vector2 startPoint;
    float angle = 0f;

    [SerializeField] float resetTime;

    [Button]
    void SpawnProjectiles()
    {
        spawnPoint = transform.position;
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {
            angle += angleStep;
            SpawnBullet(angle);
            lazerList.Add(LAZERBoss);
            StartCoroutine(ReturnLazer());
        }
    }

    void SpawnBullet(float angleRot)
    {
        LAZERBoss = pool.Get();
        LAZERBoss.SetActive(true);
        LAZERBoss.transform.rotation = Quaternion.Euler(0, 0, angleRot);
        LAZERBoss.transform.position = spawnPoint;
        LAZERBoss.GetComponent<LAZER>().Spawn(pool);
    }

    IEnumerator ReturnLazer()
    {
        if (lazerList != null)
        {
            yield return new WaitForSeconds(resetTime);

            lazerList[0].GetComponent<LAZER>().Return(pool);
            lazerList.RemoveAt(0);

            if (lazerList.Count == 0)
            {
                StopAllCoroutines();
            }
        }
        yield return null;
    }

    public void Attack()
    {
        SpawnProjectiles();
    }

}
