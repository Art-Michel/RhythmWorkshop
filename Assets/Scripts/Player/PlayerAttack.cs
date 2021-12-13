using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject _missile;
    [SerializeField] Transform _enemyPos;
    [SerializeField] Transform _northModifier;
    [SerializeField] Transform _southModifier;
    [SerializeField] Transform _eastModifier;
    [SerializeField] Transform _westModifier;

    [Range(0, 1)]
    float _t;


    public void LaunchMissile(Vector2 direction)
    {
        GameObject missile = Instantiate(_missile, transform.position, transform.rotation);
        if (direction == Vector2.up)
            missile.GetComponent<Missile>().Init(transform.position, _northModifier.position);
        if (direction == Vector2.down)
            missile.GetComponent<Missile>().Init(transform.position, _southModifier.position);
        if (direction == Vector2.left)
            missile.GetComponent<Missile>().Init(transform.position, _westModifier.position);
        if (direction == Vector2.right)
            missile.GetComponent<Missile>().Init(transform.position, _eastModifier.position);
        SoundManager.Instance.PlayLaunchMissile();
    }
}
