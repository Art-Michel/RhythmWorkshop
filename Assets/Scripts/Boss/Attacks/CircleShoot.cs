using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShoot : TempoManager
{
    [SerializeField] Pool pool;

    [SerializeField] Transform spawn;

    [SerializeField]
    public int numberOfProjectiles;

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
        angle += 15;
    }

    void SpawnBullet()
    {
        GameObject bulletBoss = pool.Get();
        SoundManager.Instance.PlayBossShoot();
        bulletBoss.SetActive(true);
        bulletBoss.transform.position = spawn.position;

        bulletBoss.GetComponent<Bullet>().Spawn(pool);
        bulletBoss.GetComponent<Rigidbody>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

    }

    public void Attack()
    {
        canAttack = true;
    }

    public void Stop()
    {
        canAttack = false;
    }

    public override void OnTheBeat()
    {
        if (canAttack == true)
        {
            SpawnProjectiles(numberOfProjectiles);
        }
    }
}