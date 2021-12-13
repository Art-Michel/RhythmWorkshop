using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNotes : LocalManager<PlayerNotes>
{
    PlayerActionMap _inputs;
    PlayerHealth playerHealth;
    PlayerAttack playerAttack;

    [Header("Button Transforms")]
    [SerializeField] Transform _northButton;
    [SerializeField] Transform _southButton;
    [SerializeField] Transform _westButton;
    [SerializeField] Transform _eastButton;
    SpriteRenderer _northButtonSprite;
    SpriteRenderer _southButtonSprite;
    SpriteRenderer _eastButtonSprite;
    SpriteRenderer _westButtonSprite;

    [Header("Button Sprites")]
    [SerializeField] Sprite _pressedNorthButton;
    [SerializeField] Sprite _unpressedNorthButton;
    [SerializeField] Sprite _pressedSouthButton;
    [SerializeField] Sprite _unpressedSouthButton;
    [SerializeField] Sprite _pressedEastButton;
    [SerializeField] Sprite _unpressedEastButton;
    [SerializeField] Sprite _pressedWestButton;
    [SerializeField] Sprite _unpressedWestButton;

    [Header("Transforms where the feedbacks will be displayed")]
    public Transform _northNoteResultUIPos;
    public Transform _southNoteResultUIPos;
    public Transform _eastNoteResultUIPos;
    public Transform _westNoteResultUIPos;

    readonly float _perfectMaxDistance = 0.06f;
    readonly float _goodMaxDistance = 0.13f;
    readonly float _missMaxDistance = 0.35f;

    [Header("Feedback prefabs")]
    [SerializeField] TextMeshProUGUI _perfectFeedback;
    [SerializeField] TextMeshProUGUI _goodFeedback;
    [SerializeField] TextMeshProUGUI _missFeedback;

    protected override void Awake()
    {
        base.Awake();
        _inputs = new PlayerActionMap();
        _inputs.Movement.NorthNote.started += NorthNotePressed;
        _inputs.Movement.NorthNote.canceled += NorthNoteReleased;

        _inputs.Movement.SouthNote.started += SouthNotePressed;
        _inputs.Movement.SouthNote.canceled += SouthNoteReleased;

        _inputs.Movement.WestNote.started += WestNotePressed;
        _inputs.Movement.WestNote.canceled += WestNoteReleased;

        _inputs.Movement.EastNote.started += EastNotePressed;
        _inputs.Movement.EastNote.canceled += EastNoteReleased;
    }

    private void Start()
    {
        _northButtonSprite = _northButton.GetComponent<SpriteRenderer>();
        _southButtonSprite = _southButton.GetComponent<SpriteRenderer>();
        _westButtonSprite = _westButton.GetComponent<SpriteRenderer>();
        _eastButtonSprite = _eastButton.GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<PlayerHealth>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void NorthNotePressed(InputAction.CallbackContext obj)
    {
        ChangeButtonSprite(_northButtonSprite, _pressedNorthButton);

        if (NotesManager.Instance._northNotes.Count > 0)
        {

            GameObject note = (GameObject)NotesManager.Instance._northNotes.Peek();
            float noteDistance = CheckDistance(note.transform.position, _northButton.position);

            if (noteDistance < _perfectMaxDistance)
                Perfect(_northNoteResultUIPos, note.GetComponent<Note>(), Vector2.up);
            else if (noteDistance < _goodMaxDistance)
                Good(_northNoteResultUIPos, note.GetComponent<Note>(), Vector2.up);
            else if (noteDistance < _missMaxDistance)
                Miss(_northNoteResultUIPos, note.GetComponent<Note>());
        }
    }

    private void SouthNotePressed(InputAction.CallbackContext obj)
    {
        ChangeButtonSprite(_southButtonSprite, _pressedSouthButton);

        if (NotesManager.Instance._southNotes.Count > 0)
        {

            GameObject note = (GameObject)NotesManager.Instance._southNotes.Peek();
            float noteDistance = CheckDistance(note.transform.position, _southButton.position);

            if (noteDistance < _perfectMaxDistance)
                Perfect(_southNoteResultUIPos, note.GetComponent<Note>(), Vector2.down);
            else if (noteDistance < _goodMaxDistance)
                Good(_southNoteResultUIPos, note.GetComponent<Note>(), Vector2.down);
            else if (noteDistance < _missMaxDistance)
                Miss(_southNoteResultUIPos, note.GetComponent<Note>());
        }
    }

    private void EastNotePressed(InputAction.CallbackContext obj)
    {
        ChangeButtonSprite(_eastButtonSprite, _pressedEastButton);

        if (NotesManager.Instance._eastNotes.Count > 0)
        {
            GameObject note = (GameObject)NotesManager.Instance._eastNotes.Peek();
            float noteDistance = CheckDistance(note.transform.position, _eastButton.position);

            if (noteDistance < _perfectMaxDistance)
                Perfect(_eastNoteResultUIPos, note.GetComponent<Note>(), Vector2.right);
            else if (noteDistance < _goodMaxDistance)
                Good(_eastNoteResultUIPos, note.GetComponent<Note>(), Vector2.right);
            else if (noteDistance < _missMaxDistance)
                Miss(_eastNoteResultUIPos, note.GetComponent<Note>());
        }
    }

    private void WestNotePressed(InputAction.CallbackContext obj)
    {
        ChangeButtonSprite(_westButtonSprite, _pressedWestButton);

        if (NotesManager.Instance._westNotes.Count > 0)
        {
            GameObject note = (GameObject)NotesManager.Instance._westNotes.Peek();
            float noteDistance = CheckDistance(note.transform.position, _westButton.position);

            if (noteDistance < _perfectMaxDistance)
                Perfect(_westNoteResultUIPos, note.GetComponent<Note>(), Vector2.left);
            else if (noteDistance < _goodMaxDistance)
                Good(_westNoteResultUIPos, note.GetComponent<Note>(), Vector2.left);
            else if (noteDistance < _missMaxDistance)
                Miss(_westNoteResultUIPos, note.GetComponent<Note>());
        }
    }

    float CheckDistance(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }

    private void Good(Transform feedbackPos, Note note, Vector2 direction)
    {
        Instantiate(_goodFeedback, feedbackPos);
        note.Death();
        playerAttack.LaunchMissile(direction);
        SoundManager.Instance.PlayGoodNote();
    }

    private void Perfect(Transform feedbackPos, Note note, Vector2 direction)
    {
        Instantiate(_perfectFeedback, feedbackPos);
        playerHealth.Heal(0.1f);
        note.Death();
        playerAttack.LaunchMissile(direction);
        SoundManager.Instance.PlayperfectNote();
    }

    public void Miss(Transform feedbackPos, Note note)
    {
        Instantiate(_missFeedback, feedbackPos);
        note.Death();
        SoundManager.Instance.PlaymissNote();
    }

    private void NorthNoteReleased(InputAction.CallbackContext obj)
    {
        ChangeButtonSprite(_northButtonSprite, _unpressedNorthButton);
    }
    private void SouthNoteReleased(InputAction.CallbackContext obj)
    {
        ChangeButtonSprite(_southButtonSprite, _unpressedSouthButton);
    }
    private void EastNoteReleased(InputAction.CallbackContext obj)
    {
        ChangeButtonSprite(_eastButtonSprite, _unpressedEastButton);
    }
    private void WestNoteReleased(InputAction.CallbackContext obj)
    {
        ChangeButtonSprite(_westButtonSprite, _unpressedWestButton);
    }

    void ChangeButtonSprite(SpriteRenderer spriteToChange, Sprite spriteToApply)
    {
        spriteToChange.sprite = spriteToApply;
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
