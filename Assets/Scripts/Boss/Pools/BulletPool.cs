using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] Pool pool;
    float spawnRate;
    [SerializeField] float maxRate;
    Transform spawn;

    public void Start()
    {
        spawn = transform;
    }

    // Update is called once per frame
    public void Update()
    {

        if (spawnRate <= 0)
        {
            SpawnBullet();
        }
        spawnRate -= Time.deltaTime;
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
