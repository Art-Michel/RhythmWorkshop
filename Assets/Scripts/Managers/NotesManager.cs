using UnityEngine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class NotesManager : LocalManager<NotesManager>
{
    [SerializeField] Transform _northSpawner;
    [SerializeField] Transform _southSpawner;
    [SerializeField] Transform _westSpawner;
    [SerializeField] Transform _eastSpawner;

    [SerializeField] Transform _northButton;
    [SerializeField] Transform _southButton;
    [SerializeField] Transform _westButton;
    [SerializeField] Transform _eastButton;
    [SerializeField] Pool _notePool;
    [SerializeField] Pool _preNotePool;


    public Queue<GameObject> _northNotes = new Queue<GameObject>();
    public Queue<GameObject> _southNotes = new Queue<GameObject>();
    public Queue<GameObject> _eastNotes = new Queue<GameObject>();
    public Queue<GameObject> _westNotes = new Queue<GameObject>();


    public void SpawnRandomNote()
    {
        
    }

    [Button]
    public void SpawnNoteNorth()
    {
        GameObject note = _notePool.Get();
        note.SetActive(true);
        note.GetComponent<Note>().InitializeNorthNote(_northSpawner, _notePool);
        GameObject preNote = _preNotePool.Get();
        preNote.SetActive(true);
        preNote.GetComponent<PreNote>().InitializePreNote(_northButton, _notePool);
    }

    [Button]
    public void SpawnNoteSouth()
    {
        GameObject note = _notePool.Get();
        note.SetActive(true);
        note.GetComponent<Note>().InitializeSouthNote(_southSpawner, _notePool);
        GameObject preNote = _preNotePool.Get();
        preNote.SetActive(true);
        preNote.GetComponent<PreNote>().InitializePreNote(_southButton, _notePool);
    }

    [Button]
    public void SpawnNoteWest()
    {
        GameObject note = _notePool.Get();
        note.SetActive(true);
        note.GetComponent<Note>().InitializeWestNote(_westSpawner, _notePool);
        GameObject preNote = _preNotePool.Get();
        preNote.SetActive(true);
        preNote.GetComponent<PreNote>().InitializePreNote(_westButton, _notePool);
    }

    [Button]
    public void SpawnNoteEast()
    {
        GameObject note = _notePool.Get();
        note.SetActive(true);
        note.GetComponent<Note>().InitializeEastNote(_eastSpawner, _notePool);
        GameObject preNote = _preNotePool.Get();
        preNote.SetActive(true);
        preNote.GetComponent<PreNote>().InitializePreNote(_eastSpawner, _notePool);
    }

}
