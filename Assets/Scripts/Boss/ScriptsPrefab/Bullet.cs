using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Pool source;
    [SerializeField] float speed;
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D other)
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
