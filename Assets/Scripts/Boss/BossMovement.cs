using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class BossMovement : MonoBehaviour
{
    bool goRight;
    bool isMovingSide;
    [SerializeField] bool goCenter;
    [SerializeField] bool goUp;

    Vector3 pos;
    [SerializeField] float speed;

    [SerializeField] Transform centerMap;
    [SerializeField] Transform upMap;

    float chrono;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        isMovingSide = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingSide == true)
        {
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
                pos.x += Time.deltaTime * speed;
            }
            else
            {
                pos.x += -Time.deltaTime * speed;
            }
            transform.position = pos;
        }
        if (goCenter == true)
        {
            StartCoroutine(Move2Center());
            chrono += Time.deltaTime;
        }
        if (goUp == true)
        {
            StartCoroutine(Move2Up());
            chrono += Time.deltaTime;
        }
    }

    IEnumerator Move2Center()
    {
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, centerMap.position.x, chrono), Mathf.Lerp(transform.position.y, centerMap.position.y, chrono));

        isMovingSide = false;
        goCenter = true;

        if (transform.position == centerMap.position)
        {
            transform.position = centerMap.position;
            goCenter = false;
            chrono = 0;
            StopCoroutine(Move2Center());
        }
        yield return null;
    }

    IEnumerator Move2Up()
    {
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, upMap.position.x, chrono), Mathf.Lerp(transform.position.y, upMap.position.y, chrono));

        goUp = true;

        if (transform.position == upMap.position)
        {
            transform.position = upMap.position;
            goUp = false;
            isMovingSide = true;
            chrono = 0;
            pos = transform.position;
            StopCoroutine(Move2Up());
        }

        yield return null;
    }
}
