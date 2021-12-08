using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class LAZERVertical : MonoBehaviour
{
    [SerializeField] Pool pool;
    [SerializeField] Transform spawn;
    Transform spawnPoint;

    [SerializeField] int length;
    [SerializeField] Vector3 addPos;

    [SerializeField] float despawn;
    [SerializeField] float maxRate;

    GameObject LAZERBoss;

    [SerializeField] List<GameObject> listLazer = new List<GameObject>();

    private void Start()
    {
        spawnPoint = spawn;
    }

    void SpawnBullet()
    {
        LAZERBoss = pool.Get();
        LAZERBoss.SetActive(true);
        LAZERBoss.transform.position = spawnPoint.position;
        LAZERBoss.GetComponent<LAZER>().Spawn(pool);
        listLazer.Add(LAZERBoss);
    }

    [Button]
    IEnumerator Shoot()
    {
        for (int i = 0; i < length; i++)
        {
            SpawnBullet();
            spawnPoint.position += addPos;

            yield return new WaitForSeconds(maxRate);
            StartCoroutine(ReturnLazer());
        }
        spawnPoint=spawn;
        yield return null;
    }

    IEnumerator ReturnLazer()
    {
        if (listLazer != null)
        {
            yield return new WaitForSeconds(despawn);

            listLazer[0].GetComponent<LAZER>().Return(pool);
            listLazer.RemoveAt(0);
        }
        yield return null;
    }
}
