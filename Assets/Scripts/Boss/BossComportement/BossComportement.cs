using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class BossComportement : MonoBehaviour
{
    [SerializeField] CircleShoot circleAttack;
    [SerializeField] SpiralAttack spiraleAttack;
    [SerializeField] LazerMid lazerMid;
    [SerializeField] LAZERVertical lazerVert;
    [SerializeField] BossMovement bossMove;

    [SerializeField] List<int> attacksPhase1 = new List<int>();
    [SerializeField] List<int> attacksPhase2 = new List<int>();
    int phase;

    float delayAttack;
    [SerializeField] float maxDelayAttack;
    [SerializeField] float difficultyAdd;
    public int a;

    private void Start()
    {
        phase = 1;
        newAttacks();
    }

    private void Update()
    {
        maxDelayAttack = Mathf.Clamp(maxDelayAttack, 2, 10);
    }

    [Button]
    public void Attacks()
    {
        if (phase == 1)
        {
            if (a < attacksPhase1.Count)
            {
                delayAttack = maxDelayAttack;
                ListAttacks();
            }
            else
            {
                a = 0;
                phase++;
            }
        }
        if (phase == 2)
        {
            if (a < attacksPhase2.Count)
            {
                Debug.Log("phase2");
                delayAttack = maxDelayAttack;
                ListAttacks();
            }
        }
    }

    void newAttacks()
    {
        for (int i = 0; i < attacksPhase2.Count; i++)
        {
            attacksPhase2[i] = Random.Range(1, 11);
        }
    }

    void ListAttacks()
    {
        if (phase == 1)
        {
            switch (attacksPhase1[a])
            {
                case 1:
                    StartCoroutine(Circle());
                    break;
                case 2:
                    StartCoroutine(Spirale());
                    break;
                case 3:
                    StartCoroutine(MidLazer());
                    break;
                case 4:
                    StartCoroutine(VertLazer());
                    break;
                case 5:
                    StartCoroutine(MoveBoss());
                    break;
            }
        }
        if (phase == 2)
        {
            switch (attacksPhase2[a])
            {
                case 1:
                case 2:
                case 3:
                    //circleAttack.numberOfProjectiles = 7;
                    StartCoroutine(Circle());
                    maxDelayAttack -= difficultyAdd;
                    break;

                case 4:
                    StartCoroutine(Circle());
                    StartCoroutine(Spirale());
                    maxDelayAttack -= difficultyAdd;
                    break;

                case 5:
                case 6:
                case 7:
                    StartCoroutine(Spirale());
                    maxDelayAttack -= difficultyAdd;
                    break;

                case 8:
                    StartCoroutine(MidLazer());
                    maxDelayAttack -= difficultyAdd;
                    break;

                case 9:
                    StartCoroutine(VertLazer());
                    maxDelayAttack -= difficultyAdd;
                    break;

                case 10:
                    StartCoroutine(MoveBoss());
                    break;
            }
        }
    }

    IEnumerator Circle()
    {
        circleAttack.Attack();
        yield return new WaitForSeconds(delayAttack);

        circleAttack.Stop();
        StopCoroutine(Circle());
        a++;
        Attacks();
        yield return null;
    }

    IEnumerator Spirale()
    {
        spiraleAttack.Attack();

        yield return new WaitForSeconds(delayAttack);

        a++;
        Attacks();
        StopCoroutine(Circle());

        yield return null;
    }


    IEnumerator MidLazer()
    {
        Debug.Log("attacks");
        lazerMid.Attack();
        yield return new WaitForSeconds(delayAttack);
        a++;
        Attacks();
        StopCoroutine(MidLazer());
    }

    IEnumerator VertLazer()
    {
        lazerVert.Attack();
        yield return new WaitForSeconds(delayAttack);

        a++;
        Attacks();
        StopCoroutine(Circle());
        yield return null;
    }

    IEnumerator MoveBoss()
    {
        bossMove.Move();
        yield return new WaitForSeconds(0.2f);
        a++;
        Attacks();
        StopCoroutine(MoveBoss());
        yield return null;
    }
}
