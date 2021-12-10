using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    float _t;
    Vector2 _p0;
    Vector2 _p1;
    Vector2 _p2;

    public void Init(Vector2 startingPoing, Vector2 intermidiatePoint)
    {
        _t = 0;
        _p0 = startingPoing;
        _p1 = intermidiatePoint;
        //_p2 = BossMovement.Instance.transform;
    }

    private void Update()
    {
        if (_t < 1)
        {
            _t += Time.deltaTime;
            LerpPositionBezier();   
        }
        else
            Explode();
    }

    private void Explode()
    {
        Debug.Log("boom");
    }

    Vector2 LerpPositionBezier()
    {
        //(1-t)^2*P0 + 2(1-t)tP1 + t^2*P2
        //  u           u
        //   uu*P0 + 2 *u * t* P1 + tt * P2
        float u = 1 - _t;
        float tt = _t * _t;
        float uu = u * u;

        Vector2 point = uu * _p0;
        point += 2 * u * _t * _p1;
        point += tt * _p2;
        return point;
    }
}
