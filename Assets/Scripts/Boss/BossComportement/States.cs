using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class States : MonoBehaviour
{
    public virtual void Start()
    {
        
    }

    public virtual IEnumerator SpiralAttack()
    {
        yield break;
    }

    public virtual IEnumerator LazerVert()
    {
        yield break;

    }

    public virtual IEnumerator LazerMidAttack()
    {
        yield break;

    }

    public virtual IEnumerator CircleShootAttack()
    {
        yield break;
    }
}
