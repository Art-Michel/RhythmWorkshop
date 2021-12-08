using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAZERVertical : MonoBehaviour
{
    [SerializeField] Pool pool;
    float spawnRate;
    [SerializeField] float maxRate;
    [SerializeField] Transform spawn;
    [SerializeField] int length;
    [SerializeField] Vector3 addPos;

    GameObject LAZERBoss;

    [SerializeField] bool canShoot;
    [SerializeField] List<GameObject> listLazer = new List<GameObject>();

    public void Start()
    {
    }

    private void Update()
    {
        if (canShoot == true)
        {
            Shoot();
        }

        spawnRate -= Time.deltaTime;
    }

    void SpawnBullet()
    {
        LAZERBoss = pool.Get();
        LAZERBoss.SetActive(true);
        LAZERBoss.transform.position = spawn.position;
        LAZERBoss.GetComponent<LAZER>().Spawn(pool);
        listLazer.Add(LAZERBoss);
    }

    void Return()
    {
        LAZERBoss.GetComponent<LAZER>().Return(pool);
    }

    void Shoot()
    {
        for (int i = 0; i < length; i++)
        {
            if (spawnRate <= 0)
            {
                spawnRate = maxRate;
                SpawnBullet();
                spawn.position += addPos;
            }
        }
    }
}
