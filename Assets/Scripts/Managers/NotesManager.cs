using UnityEngine;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;

public class NotesManager : LocalManager<NotesManager>
{
    [SerializeField] Transform _northSpawner;
    [SerializeField] Transform _southSpawner;
    [SerializeField] Transform _westSpawner;
    [SerializeField] Transform _eastSpawner;

    public Queue<GameObject> _northNotes = new Queue<GameObject>();
    public Queue<GameObject> _southNotes = new Queue<GameObject>();
    public Queue<GameObject> _eastNotes = new Queue<GameObject>();
    public Queue<GameObject> _westNotes = new Queue<GameObject>();

    [SerializeField] GameObject _notePrefab;

    [Button]
    void SpawnNoteNorth()
    {
        GameObject obj = Instantiate(_notePrefab, _northSpawner);
        obj.GetComponent<Note>().InitializeNorthNote(_northSpawner);
    }

    [Button]
    void SpawnNoteSouth()
    {
        GameObject obj = Instantiate(_notePrefab, _southSpawner);
        obj.GetComponent<Note>().InitializeSouthNote(_southSpawner);
    }

    [Button]
    void SpawnNoteWest()
    {
        GameObject obj = Instantiate(_notePrefab, _westSpawner);
        obj.GetComponent<Note>().InitializeWestNote(_westSpawner);
    }

    [Button]
    void SpawnNoteEast()
    {
        GameObject obj = Instantiate(_notePrefab, _eastSpawner);
        obj.GetComponent<Note>().InitializeEastNote(_eastSpawner);
    }
}
