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
        GameObject note = NotesManager.Instance._northNotes.Peek();
        float noteDistance = CheckDistance(note.transform.position, _northButton.position);
        if (noteDistance<0.2f)
            Perfect();
        else if (noteDistance<0.4f)
            Good();
    }

    private void SouthNotePressed(InputAction.CallbackContext obj)
    {
        GameObject note = NotesManager.Instance._southNotes.Peek();
        float noteDistance = CheckDistance(note.transform.position, _southButton.position);
        if (noteDistance<0.2f)
            Perfect();
        else if (noteDistance<0.4f)
            Good();
    }

    private void EastNotePressed(InputAction.CallbackContext obj)
    {
        GameObject note = NotesManager.Instance._eastNotes.Peek();
        float noteDistance = CheckDistance(note.transform.position, _eastButton.position);
        if (noteDistance<0.2f)
            Perfect();
        else if (noteDistance<0.4f)
            Good();
    }

    private void WestNotePressed(InputAction.CallbackContext obj)
    {
        GameObject note = NotesManager.Instance._westNotes.Peek();
        float noteDistance = CheckDistance(note.transform.position, _westButton.position);
        if (noteDistance<0.2f)
            Perfect();
        else if (noteDistance<0.4f)
            Good();
    }

    float CheckDistance(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }

    private void Good()
    {
        Debug.Log("good");
    }

    private void Perfect()
    {
        Debug.Log("perfect");
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
