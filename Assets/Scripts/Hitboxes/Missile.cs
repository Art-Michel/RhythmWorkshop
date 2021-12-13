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

    public void Init(Vector2 startingPoint, Vector2 intermidiatePoint)
    {
        _t = 0;
        _p0 = startingPoint;
        _p1 = intermidiatePoint;
    }

    private void Update()
    {
        if (_t < 1)
        {
            _t += Time.deltaTime;
            UpdateBossPosition();
            Vector2 wantedPos = LerpPositionBezier();
            UpdateRotation(wantedPos);
            transform.position = wantedPos;
        }
        else
            Explode();
    }

    private void UpdateRotation(Vector3 point)
    {
        transform.up = point - transform.position;
    }

    private void UpdateBossPosition()
    {
        _p2 = BossHp.Instance.transform.position;
    }

    private void Explode()
    {
        SoundManager.Instance.PlayexplosionLight();
        BossHp.Instance.TakeDamage(10);
        Destroy(gameObject);
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
