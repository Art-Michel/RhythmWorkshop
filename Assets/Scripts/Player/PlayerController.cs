using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController _charaCon;

    private void Start()
    {
        _charaCon = GetComponent<CharacterController>();
    }
}
