using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShoot : MonoBehaviour
{
    [SerializeField] Pool pool;

    float spawnRate;

    [SerializeField] float maxRate;
    [SerializeField] Transform spawn;
    Vector3 dir = new Vector3(0, 0, 1);
    GameObject bulletBoss;

    [SerializeField]
    int numberOfProjectiles;

    [SerializeField] bool canAttack;

    Vector2 startPoint;
    Vector2 projectileVector;
    Vector2 projectileMoveDirection;
    float angle = 0f;
    [SerializeField] float moveSpeed;

    float radius;

    // Use this for initialization
    public void Start()
    {
        radius = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate -= Time.deltaTime;
        if (spawnRate <= 0 && canAttack == true)
        {
            SpawnProjectiles(numberOfProjectiles);
            spawnRate = maxRate;
        }
    }

    void SpawnProjectiles(int numberOfProjectiles)
    {
        float angleStep = 360f / numberOfProjectiles;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {
            float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

            SpawnBullet();
            angle += angleStep;
        }
        angle+=15;
    }

    void SpawnBullet()
    {
        GameObject bulletBoss = pool.Get();
        bulletBoss.SetActive(true);
        bulletBoss.transform.position = spawn.position;

        bulletBoss.GetComponent<Bullet>().Spawn(pool);
        bulletBoss.GetComponent<Rigidbody>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

        spawnRate = maxRate;
    }

    public void Attack()
    {
        canAttack = true;
    }

    public void Stop()
    {
        canAttack = false;
    }
}