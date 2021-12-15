using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Pool _pool;

    [SerializeField] GameObject _missile;
    [SerializeField] Transform _enemyPos;
    [SerializeField] Transform _northModifier;
    [SerializeField] Transform _southModifier;
    [SerializeField] Transform _eastModifier;
    [SerializeField] Transform _westModifier;

    [Range(0, 1)]
    float _t;


    public void LaunchMissile(Vector2 direction, bool perfect)
    {
        GameObject missile = _pool.Get();
        missile.SetActive(true);
        missile.transform.position = transform.position;
        if (direction == Vector2.up)
            missile.GetComponent<Missile>().Init(transform.position, _northModifier.position, _pool, perfect);
        if (direction == Vector2.down)
            missile.GetComponent<Missile>().Init(transform.position, _southModifier.position, _pool, perfect);
        if (direction == Vector2.left)
            missile.GetComponent<Missile>().Init(transform.position, _westModifier.position, _pool, perfect);
        if (direction == Vector2.right)
            missile.GetComponent<Missile>().Init(transform.position, _eastModifier.position, _pool, perfect);
        SoundManager.Instance.PlayLaunchMissile();
    }
}
