using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class LAZERVertical : MonoBehaviour
{
    [SerializeField] Pool pool;
    [SerializeField] Transform spawnOrigin;
    Vector3 spawnPoint;

    [SerializeField] int length;
    [SerializeField] Vector3 addPos;
    public bool attackOver;

    [SerializeField] float despawn;
    [SerializeField] float maxRate;

    GameObject LAZERBoss;

    [SerializeField] List<GameObject> listLazer = new List<GameObject>();

    private void Start()
    {
        spawnPoint = spawnOrigin.position;
        attackOver = false;
    }

    void SpawnBullet()
    {
        LAZERBoss = pool.Get();
        LAZERBoss.SetActive(true);
        LAZERBoss.transform.position = spawnPoint;
        LAZERBoss.GetComponent<LAZER>().Spawn(pool);
        listLazer.Add(LAZERBoss);
    }

    [Button]
    IEnumerator Shoot()
    {
        for (int i = 0; i < length; i++)
        {
            SpawnBullet();
            spawnPoint += addPos;

            yield return new WaitForSeconds(maxRate);
            StartCoroutine(ReturnLazer());
        }
        yield return null;
    }

    IEnumerator ReturnLazer()
    {
        if (listLazer != null)
        {
            yield return new WaitForSeconds(despawn);

            listLazer[0].GetComponent<LAZER>().Return(pool);
            listLazer.RemoveAt(0);

            if (listLazer.Count == 0)
            {
                spawnPoint = spawnOrigin.position;
                attackOver = true;
                StopAllCoroutines();
            }
        }
        yield return null;
    }

    public void Attack()
    {
        StartCoroutine(Shoot());
    }
}
