using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform _enemyPos;
    [SerializeField] Transform _rightModifier;
    [SerializeField] Transform _leftModifier;

    [Range(0, 1)]
    float _t;


    public void LaunchMissile()
    {

    }
}
