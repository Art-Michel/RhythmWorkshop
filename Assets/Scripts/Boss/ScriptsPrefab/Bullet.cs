using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Pool source;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sides"))
        {
            source.Back(gameObject);
        }
    }

    public void Spawn(Pool pool)
    {
        source = pool;
    }
}
