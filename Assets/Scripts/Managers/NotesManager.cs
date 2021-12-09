using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;

public class NotesManager : LocalManager<NotesManager>
{
    [SerializeField] Transform _northSpawner;
    [SerializeField] Transform _southSpawner;
    [SerializeField] Transform _westSpawner;
    [SerializeField] Transform _eastSpawner;

    public Queue<GameObject> _northNotes { get; private set; }
    public Queue<GameObject> _southNotes { get; private set; }
    public Queue<GameObject> _eastNotes { get; private set; }
    public Queue<GameObject> _westNotes { get; private set; }

    [SerializeField] GameObject _notePrefab;

    [Button]
    void SpawnNoteNorth()
    {
        GameObject obj = Instantiate(_notePrefab, _northSpawner);
        obj.GetComponent<Note>().NoteDirection = Vector3.down;
        _northNotes.Enqueue(obj);
    }

    [Button]
    void SpawnNoteSouth()
    {
        GameObject obj = Instantiate(_notePrefab, _southSpawner);
        obj.GetComponent<Note>().NoteDirection = Vector3.up;
        _southNotes.Enqueue(obj);
    }

    [Button]
    void SpawnNoteWest()
    {
        GameObject obj = Instantiate(_notePrefab, _westSpawner);
        obj.GetComponent<Note>().NoteDirection = Vector3.right;
        _westNotes.Enqueue(obj);
    }

    [Button]
    void SpawnNoteEast()
    {
        GameObject obj = Instantiate(_notePrefab, _eastSpawner);
        obj.GetComponent<Note>().NoteDirection = Vector3.left;
        _eastNotes.Enqueue(obj);
    }
}
