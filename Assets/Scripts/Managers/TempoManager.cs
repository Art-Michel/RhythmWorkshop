using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoManager : MonoBehaviour
{
    public float bpm;
    public float maxRate;
    float beatTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        maxRate = 60 / bpm;
        beatTime += Time.deltaTime;

        if (beatTime >= maxRate)
        {
            OnTheBeat();
            beatTime -= maxRate;
        }
    }

    public virtual void OnTheBeat()
    {

    }
}
