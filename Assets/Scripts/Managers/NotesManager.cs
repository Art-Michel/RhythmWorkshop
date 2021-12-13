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
    [SerializeField] Pool _pool;


    public Queue<GameObject> _northNotes = new Queue<GameObject>();
    public Queue<GameObject> _southNotes = new Queue<GameObject>();
    public Queue<GameObject> _eastNotes = new Queue<GameObject>();
    public Queue<GameObject> _westNotes = new Queue<GameObject>();

    [SerializeField] GameObject _notePrefab;


    [Button]
    void SpawnNoteNorth()
    {
        GameObject obj = _pool.Get();
        obj.SetActive(true);
        obj.GetComponent<Note>().InitializeNorthNote(_northSpawner, _pool);
    }

    [Button]
    void SpawnNoteSouth()
    {
        GameObject obj = _pool.Get();
        obj.SetActive(true);
        obj.GetComponent<Note>().InitializeSouthNote(_southSpawner, _pool);
    }

    [Button]
    void SpawnNoteWest()
    {
        GameObject obj = _pool.Get();
        obj.SetActive(true);
        obj.GetComponent<Note>().InitializeWestNote(_westSpawner, _pool);
    }

    [Button]
    void SpawnNoteEast()
    {
        GameObject obj = _pool.Get();
        obj.SetActive(true);
        obj.GetComponent<Note>().InitializeEastNote(_eastSpawner, _pool);
    }

}
