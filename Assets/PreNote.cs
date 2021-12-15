using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreNote : MonoBehaviour
{
    float _t = 0;
    Pool _pool;

   public void InitializePreNote(Transform button, Pool pool)
    {
        this._pool = pool;
        transform.parent = button;
        transform.localPosition = Vector3.zero;
    }
    void Update()
    {
        _t += Time.deltaTime * 0.72f;
        float scale = Mathf.Lerp(0.75f, 0.28f, _t);
        transform.localScale = new Vector3(scale,scale,scale);
        if (_t >=1)
        {
            _pool.Back(gameObject);
        }
    }
}
