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

    [SerializeField] TextMeshProUGUI _scoreUI;
    [SerializeField] TextMeshProUGUI _comboUI;

    float _missedNotes = 0;
    float _goodedNotes = 0;
    float _perfectedNotes = 0;
    float _score;
    float _currentCombo;
    float _longestCombo;

    public Queue<GameObject> _northNotes = new Queue<GameObject>();
    public Queue<GameObject> _southNotes = new Queue<GameObject>();
    public Queue<GameObject> _eastNotes = new Queue<GameObject>();
    public Queue<GameObject> _westNotes = new Queue<GameObject>();

    [SerializeField] GameObject _notePrefab;

    void Start()
    {
        _currentCombo = 0;
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
        _currentCombo = 0;
        CalculateScore();
    }

    public void AddGood()
    {
        _goodedNotes++;
        _currentCombo++;
        CalculateScore(100);
    }

    public void AddPerfect()
    {
        _perfectedNotes++;
        _currentCombo++;
        CalculateScore(200);
    }

    void CalculateScore(float additionnalScore = 0)
    {
        if (additionnalScore != 0)
        {
            _score += additionnalScore + _currentCombo * 10;
            _scoreUI.text = ("Score: " + _score);
            if (_currentCombo > _longestCombo)
                _longestCombo = _currentCombo;
        }
        _comboUI.text = (_currentCombo.ToString());
        _comboUI.color = RemapColor(0, 30, Color.white, Color.red, _currentCombo);
        _comboUI.fontSize = Remap(0, 30, 32, 64, _currentCombo);
        Debug.Log("Combo: " + _currentCombo);
        //ToDo Display Score, longest Combo, and number of each miss, good and perfect in Game Over Screen
    }

    float Remap(float iMin, float iMax, float oMin, float oMax, float v)
    {
        float t = Mathf.InverseLerp(iMin, iMax, v);
        return Mathf.Lerp(oMin, oMax, t);
    }

    Color RemapColor(float iMin, float iMax, Color color1, Color color2, float v)
    {
        float t = Mathf.InverseLerp(iMin, iMax, v);
        return Color.Lerp(color1, color2, t);
    }
}
