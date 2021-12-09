using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Note : MonoBehaviour
{
    public Vector3 NoteDirection;
    [SerializeField] float _speed;
    [SerializeField] float _lifeSpan;
    float timer;

    public void InitializeNorthNote(Transform noteParent)
    {
        transform.parent = noteParent;
        NotesManager.Instance._northNotes.Enqueue(gameObject);
        NoteDirection = Vector3.down;
        timer = 0;
    }

    public void InitializeWestNote(Transform noteParent)
    {
        transform.parent = noteParent;
        NotesManager.Instance._westNotes.Enqueue(gameObject);
        NoteDirection = Vector3.right;
        timer = 0;
    }

    public void InitializeEastNote(Transform noteParent)
    {
        transform.parent = noteParent;
        NotesManager.Instance._eastNotes.Enqueue(gameObject);
        NoteDirection = Vector3.left;
        timer = 0;
    }

    public void InitializeSouthNote(Transform noteParent)
    {
        transform.parent = noteParent;
        NotesManager.Instance._southNotes.Enqueue(gameObject);
        NoteDirection = Vector3.up;
        timer = 0;
    }

    private void Update()
    {
        transform.position += (NoteDirection * _speed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > _lifeSpan)
            ForceMiss();
    }

    private void ForceMiss()
    {
        switch (transform.parent.tag)
        {
            case "North":
                PlayerNotes.Instance.Miss(PlayerNotes.Instance._northNoteResultUIPos, this);
                break;

            case "South":
                PlayerNotes.Instance.Miss(PlayerNotes.Instance._southNoteResultUIPos, this);
                break;

            case "East":
                PlayerNotes.Instance.Miss(PlayerNotes.Instance._eastNoteResultUIPos, this);
                break;

            case "West":
                PlayerNotes.Instance.Miss(PlayerNotes.Instance._westNoteResultUIPos, this);
                break;
        }
    }

    public void Death()
    {
        switch (transform.parent.tag)
        {
            case "North":
                NotesManager.Instance._northNotes.Dequeue();
                Destroy(gameObject);
                break;

            case "South":
                NotesManager.Instance._southNotes.Dequeue();
                Destroy(gameObject);
                break;

            case "East":
                NotesManager.Instance._eastNotes.Dequeue();
                Destroy(gameObject);
                break;

            case "West":
                NotesManager.Instance._westNotes.Dequeue();
                Destroy(gameObject);
                break;
        }
    }
}
