using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAZERPool : MonoBehaviour
{
    [SerializeField] Pool pool;
    float spawnRate;
    [SerializeField] float maxRate;
    Transform spawn;

    public void Start()
    {
        spawn = transform;
    }

    void SpawnBullet()
    {
        GameObject bulletBoss = pool.Get();
        bulletBoss.SetActive(true);
        bulletBoss.transform.position = spawn.position;
        bulletBoss.GetComponent<Bullet>().Spawn(pool);
        spawnRate = maxRate;
    }
}
