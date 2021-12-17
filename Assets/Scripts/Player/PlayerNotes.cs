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

    float _northButtonFeedbackCooldown = 0;
    float _eastButtonFeedbackCooldown = 0;
    float _westButtonFeedbackCooldown = 0;
    float _southButtonFeedbackCooldown = 0;
    bool _northButtonSizeIsNormal = true;
    bool _southButtonSizeIsNormal = true;
    bool _westButtonSizeIsNormal = true;
    bool _eastButtonSizeIsNormal = true;

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

    readonly float _perfectMaxDistance = 0.065f;
    readonly float _goodMaxDistance = 0.15f;
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

    void Update()
    {
        _northButtonFeedbackCooldown -= Time.deltaTime;
        _southButtonFeedbackCooldown -= Time.deltaTime;
        _eastButtonFeedbackCooldown -= Time.deltaTime;
        _westButtonFeedbackCooldown -= Time.deltaTime;

        Debug.Log(_northButtonFeedbackCooldown);
        Debug.Log(_northButtonSizeIsNormal);

        if (_northButtonFeedbackCooldown <= 0 && !_northButtonSizeIsNormal)
        {
            _northButton.localScale = Vector3.one * 0.35f;
            _northButtonSizeIsNormal = true;
        }
        if (_southButtonFeedbackCooldown <= 0 && !_southButtonSizeIsNormal)
        {
            _southButton.localScale = Vector3.one * 0.35f;
            _southButtonSizeIsNormal = true;
        }
        if (_eastButtonFeedbackCooldown <= 0 && !_eastButtonSizeIsNormal)
        {
            _eastButton.localScale = Vector3.one * 0.35f;
            _eastButtonSizeIsNormal = true;
        }
        if (_westButtonFeedbackCooldown <= 0 && !_westButtonSizeIsNormal)
        {
            _westButton.localScale = Vector3.one * 0.35f;
            _westButtonSizeIsNormal = true;
        }
    }

    private void NorthNotePressed(InputAction.CallbackContext obj)
    {
        ChangeButtonSprite(_northButtonSprite, _pressedNorthButton);

        if (NotesManager.Instance._northNotes.Count > 0)
        {

            GameObject note = (GameObject)NotesManager.Instance._northNotes.Peek();
            float noteDistance = CheckDistance(note.transform.position, _northButton.position);

            if (noteDistance < _perfectMaxDistance)
            {
                Perfect(_northNoteResultUIPos, note.GetComponent<Note>(), Vector2.up);
                ChangeButtonScale(_northButton,0.5f);
            }
            else if (noteDistance < _goodMaxDistance)
            {
                Good(_northNoteResultUIPos, note.GetComponent<Note>(), Vector2.up);
                ChangeButtonScale(_northButton, 0.42f);
            }
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
            {
                Perfect(_southNoteResultUIPos, note.GetComponent<Note>(), Vector2.down);
                ChangeButtonScale(_southButton,0.5f);
            }
            else if (noteDistance < _goodMaxDistance)
            {
                Good(_southNoteResultUIPos, note.GetComponent<Note>(), Vector2.down);
                ChangeButtonScale(_southButton, 0.42f);
            }
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
            {
                Perfect(_eastNoteResultUIPos, note.GetComponent<Note>(), Vector2.right);
                ChangeButtonScale(_eastButton,0.5f);
            }
            else if (noteDistance < _goodMaxDistance)
            {
                Good(_eastNoteResultUIPos, note.GetComponent<Note>(), Vector2.right);
                ChangeButtonScale(_eastButton, 0.42f);
            }
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
            {
                Perfect(_westNoteResultUIPos, note.GetComponent<Note>(), Vector2.left);
                ChangeButtonScale(_westButton, 0.5f);
            }
            else if (noteDistance < _goodMaxDistance)
            {
                Good(_westNoteResultUIPos, note.GetComponent<Note>(), Vector2.left);
                ChangeButtonScale(_westButton, 0.4f);
            }
            else if (noteDistance < _missMaxDistance)
                Miss(_westNoteResultUIPos, note.GetComponent<Note>());
        }
    }

    void ChangeButtonScale(Transform button, float size)
    {
        button.localScale = Vector3.one * size;
        switch (button.tag)
        {
            case "South":
                _southButtonSizeIsNormal = false;
                _southButtonFeedbackCooldown = 0.07f;
                break;

            case "North":
                _northButtonSizeIsNormal = false;
                _northButtonFeedbackCooldown = 0.07f;
                break;

            case "East":
                _eastButtonSizeIsNormal = false;
                _eastButtonFeedbackCooldown = 0.07f;
                break;

            case "West":
                _westButtonSizeIsNormal = false;
                _westButtonFeedbackCooldown = 0.07f;
                break;
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
        playerAttack.LaunchMissile(direction, false);
        ScoreManager.Instance.AddGood();
        SoundManager.Instance.PlayGoodNote();
    }

    private void Perfect(Transform feedbackPos, Note note, Vector2 direction)
    {
        Instantiate(_perfectFeedback, feedbackPos);
        playerHealth.Heal(0.1f);
        note.Death();
        playerAttack.LaunchMissile(direction, true);
        ScoreManager.Instance.AddPerfect();
        SoundManager.Instance.PlayperfectNote();
    }

    public void Miss(Transform feedbackPos, Note note)
    {
        Instantiate(_missFeedback, feedbackPos);
        note.Death();
        ScoreManager.Instance.AddMiss();
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
