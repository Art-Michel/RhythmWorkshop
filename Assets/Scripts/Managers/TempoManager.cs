using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoManager : MonoBehaviour
{
    [SerializeField] float bpm;
    public float maxRate;
    float beatTime;

    [SerializeField] Animator animBossHp;

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
        animBossHp.SetTrigger("Boom");
    }
}
