using UnityEngine;
using NaughtyAttributes;

public class NotesManager : LocalManager<NotesManager>
{
    [SerializeField] Transform _northSpawner;
    [SerializeField] Transform _southSpawner;
    [SerializeField] Transform _westSpawner;
    [SerializeField] Transform _eastSpawner;

    [SerializeField] GameObject _notePrefab;

    [Button]
    void SpawnNoteNorth()
    {
        GameObject obj = Instantiate(_notePrefab, _northSpawner);
        obj.tag = "NorthNote";
        obj.GetComponent<Note>().NoteDirection = Vector3.down;
    }

    [Button]
    void SpawnNoteSouth()
    {
        GameObject obj = Instantiate(_notePrefab, _southSpawner);
        obj.tag = "SouthNote";
        obj.GetComponent<Note>().NoteDirection = Vector3.up;
    }

    [Button]
    void SpawnNoteWest()
    {
        GameObject obj = Instantiate(_notePrefab, _westSpawner);
        obj.tag = "WestNote";
        obj.GetComponent<Note>().NoteDirection = Vector3.right;
    }
    
    [Button]
    void SpawnNoteEast()
    {
        GameObject obj = Instantiate(_notePrefab, _eastSpawner);
        obj.tag = "EastNote";
        obj.GetComponent<Note>().NoteDirection = Vector3.left;
    }
}
