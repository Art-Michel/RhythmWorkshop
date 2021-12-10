using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class BossMovement : LocalManager<BossMovement>
{
    bool goRight;
    bool isMovingSide;
    [SerializeField] bool goCenter;
    [SerializeField] bool goUp;

    Vector3 pos;
    [SerializeField] float speed;
    [SerializeField] float speedMov;
    [SerializeField] float maxX;
    float time;
    float x;

    [SerializeField] Transform centerMap;
    [SerializeField] Transform upMap;

    float chrono;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        isMovingSide = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingSide == true)
        {
            time += Time.deltaTime;
            x = maxX * Mathf.Sin(speed * time);
            transform.localPosition = new Vector3(pos.x + x, pos.y, pos.z);
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
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, centerMap.position.x, chrono*speedMov), Mathf.Lerp(transform.position.y, centerMap.position.y, chrono));

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
            time=0;
            x=pos.x;
            pos = transform.position;
            StopCoroutine(Move2Up());
        }

        yield return null;
    }
}
