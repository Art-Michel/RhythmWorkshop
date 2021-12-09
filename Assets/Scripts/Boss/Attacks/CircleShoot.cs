using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShoot : MonoBehaviour, Comportement
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

    float radius, moveSpeed;

    // Use this for initialization
    public void Start()
    {
        radius = 5f;
        moveSpeed = 5f;
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
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {
            float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

            SpawnBullet();

            angle += angleStep;
        }
    }

    void SpawnBullet()
    {
        GameObject bulletBoss = pool.Get();
        bulletBoss.SetActive(true);
        bulletBoss.transform.position = spawn.position;

        bulletBoss.GetComponent<Bullet>().Spawn(pool);
        bulletBoss.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

        spawnRate = maxRate;
    }

    void Comportement.Attack()
    {
        canAttack = true;
    }

    void Comportement.Stop()
    {
        canAttack = false;
    }
}