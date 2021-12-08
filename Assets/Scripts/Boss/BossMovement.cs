using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    bool goRight;
    Vector3 pos;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos;
        if (transform.position.x <= -1.5f)
        {
            goRight = true;
        }
        else if (transform.position.x >= 1.5f)
        {
            goRight = false;
        }
        if (goRight == true)
        {
            pos.x += Time.deltaTime*speed;
        }
        else
        {
            pos.x += -Time.deltaTime*speed;
        }
    }
}
