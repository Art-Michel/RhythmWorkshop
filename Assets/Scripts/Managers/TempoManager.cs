using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoManager : MonoBehaviour
{
    [SerializeField] float bpm;
    public bool boomHp;
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
            if (boomHp == true)
            {
                AnimOnTheBeat();
            }
            OnTheBeat();
            beatTime -= maxRate;
        }
    }

    public void AnimOnTheBeat()
    {
        animBossHp.SetTrigger("Boom");
    }

    public virtual void OnTheBeat()
    {

    }

    public void StartBeat()
    {
        boomHp = true;
    }

    public void StopBeat()
    {
        boomHp = false;
    }
}
