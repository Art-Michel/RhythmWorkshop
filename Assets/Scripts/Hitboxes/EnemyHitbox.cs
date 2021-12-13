using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 knockbackDirection = (PlayerHealth.Instance.transform.position - transform.position).normalized;
            PlayerHealth.Instance.TakeDamage(1, 0.25f, knockbackDirection);
        }
    }
}
