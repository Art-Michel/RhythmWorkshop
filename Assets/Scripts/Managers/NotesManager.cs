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
    [SerializeField] Pool _pool;

    float _missedNotes = 0;
    float _goodedNotes = 0;
    float _perfectedNotes = 0;
    float _score;
    float _combo;
    float _longestCombo;

    public Queue<GameObject> _northNotes = new Queue<GameObject>();
    public Queue<GameObject> _southNotes = new Queue<GameObject>();
    public Queue<GameObject> _eastNotes = new Queue<GameObject>();
    public Queue<GameObject> _westNotes = new Queue<GameObject>();

    [SerializeField] GameObject _notePrefab;

    void Start()
    {
        _combo = 0;
        _longestCombo = 0;
        _score = 0;
    }

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

    public void AddMiss()
    {
        _missedNotes++;
        _combo = 0;
    }

    public void AddGood()
    {
        _goodedNotes++;
        _combo++;
        CalculateScore(100);
    }

    public void AddPerfect()
    {
        _perfectedNotes++;
        _combo++;
        CalculateScore(200);
    }

    void CalculateScore(float additionnalScore)
    {
        _score += additionnalScore + _combo * 10;
        if (_combo > _longestCombo)
            _longestCombo = _combo;
        Debug.Log("Score: " + _score);
        Debug.Log("Combo: " + _combo);
        //ToDo display Score and current Combo
        //ToDo Display Score, longest Combo, and number of each miss, good and perfect in Game Over Screen
    }
}
