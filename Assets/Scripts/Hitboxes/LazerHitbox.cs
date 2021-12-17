using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerHitbox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth.Instance.TakeDamage(2);
        }
    }
}
