using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNotes : MonoBehaviour
{
    PlayerActionMap _inputs;

    [SerializeField] Transform _northButton;
    [SerializeField] Transform _southButton;
    [SerializeField] Transform _westButton;
    [SerializeField] Transform _eastButton;

    [SerializeField] Transform _northSpawner;
    [SerializeField] Transform _southSpawner;
    [SerializeField] Transform _westSpawner;
    [SerializeField] Transform _eastSpawner;

    [SerializeField] Transform _temporaryNote;

    private void Awake()
    {
        _inputs = new PlayerActionMap();
        _inputs.Movement.NorthNote.started += NorthNotePressed;
        _inputs.Movement.SouthNote.started += SouthNotePressed;
        _inputs.Movement.WestNote.started += WestNotePressed;
        _inputs.Movement.EastNote.started += EastNotePressed;

    }

    private void NorthNotePressed(InputAction.CallbackContext obj)
    {
        CheckDistance(_temporaryNote.position, _northButton.position);
    }

    private void SouthNotePressed(InputAction.CallbackContext obj)
    {
        CheckDistance(_temporaryNote.position, _southButton.position);
    }

    private void EastNotePressed(InputAction.CallbackContext obj)
    {
        CheckDistance(_temporaryNote.position, _eastButton.position);
    }

    private void WestNotePressed(InputAction.CallbackContext obj)
    {
        CheckDistance(_temporaryNote.position, _westButton.position);
    }

    void CheckDistance(Vector3 a, Vector3 b)
    {
        float distance = Vector3.Distance(a, b);
        Debug.Log(distance);
    }

    #region disable inputs on Player disable to avoid weird inputs
    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }
    #endregion
}
