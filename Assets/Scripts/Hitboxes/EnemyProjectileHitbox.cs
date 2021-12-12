using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileHitbox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth.Instance.TakeDamage(1);
            //! mais cynthia tu m'as menti il faut un rigidbody là wtf
        }
    }
}
