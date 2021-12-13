using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SpiralAttack : MonoBehaviour
{
    [SerializeField] Pool pool;
    [SerializeField] float maxSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] int maxTurns;
    [SerializeField] int maxProj;
    Transform spawn;
    public bool attackOver;

    Vector2 startPoint;
    Vector2 projectileVector;
    Vector2 projectileMoveDirection;

    public void Start()
    {
        spawn = transform;
        attackOver = false;
    }

    // private void Update()
    // {
    //     if (attackOver == true)
    //     {
    //         StopAllCoroutines();
    //     }
    // }

    IEnumerator Spiral()
    {
        float angleStep = 360f / maxProj;
        float angle = 0f;
        for (int i = 0; i < maxTurns; i++)
        {
            for (int j = 0; j <= maxProj - 1; j++)
            {
                float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180);
                float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180);

                projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
                projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

                SpawnBullet();

                angle += angleStep;
                yield return new WaitForSeconds(maxSpeed);
            }
            angle+=15;
        }
        attackOver = true;
        yield return null;
    }

    void SpawnBullet()
    {
        GameObject bulletBoss = pool.Get();
        bulletBoss.SetActive(true);
        bulletBoss.transform.position = spawn.position;
        bulletBoss.GetComponent<Bullet>().Spawn(pool);
        bulletBoss.GetComponent<Rigidbody>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
    }

    [Button]
    public void Attack()
    {
        attackOver=false;
        StartCoroutine(Spiral());
    }

}
