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
    [SerializeField] List<int> attacks = new List<int>();
    float delayAttack;
    [SerializeField] float maxDelayAttack;
    public int a;

    [Button]
    void AttacksPhase1()
    {
        if (a < attacks.Count)
        {
            delayAttack=maxDelayAttack;
            ListAttacks();
        }
    }

    void ListAttacks()
    {
        switch (attacks[a])
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
        }
    }

    IEnumerator Circle()
    {
        circleAttack.Attack();
        yield return new WaitForSeconds(delayAttack);

        circleAttack.Stop();
        StopCoroutine(Circle());
        a++;
        AttacksPhase1();
        yield return null;
    }

    IEnumerator Spirale()
    {
        delayAttack-= maxDelayAttack/2;
        spiraleAttack.Attack();

        yield return new WaitForSeconds(delayAttack);

        a++;
        AttacksPhase1();
        StopCoroutine(Circle());

        yield return null;
    }


    IEnumerator MidLazer()
    {
        Debug.Log("attacks");
        lazerMid.Attack();
        delayAttack-=maxDelayAttack/2;
        yield return new WaitForSeconds(delayAttack);
        a++;
        AttacksPhase1();
        StopCoroutine(MidLazer());
    }

    IEnumerator VertLazer()
    {
        lazerVert.Attack();
        yield return new WaitForSeconds(delayAttack);

        a++;
        AttacksPhase1();
        StopCoroutine(Circle());
        yield return null;
    }
}
