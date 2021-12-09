using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFeedback : MonoBehaviour
{
    float _lifeSpan = 0.8f;
    float speed = 0.2f;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > _lifeSpan)
            Destroy(gameObject);
    }
}
