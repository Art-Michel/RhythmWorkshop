using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementTest : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxX;
    Vector3 pos;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        float x = maxX * Mathf.Sin(speed * time);
        Debug.Log("x="+x);
        transform.localPosition = new Vector3( pos.x+x, pos.y, pos.z);
    }
}
