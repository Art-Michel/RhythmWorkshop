using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GameManager : LocalManager<GameManager>
{

    private void Start() 
    {
        Time.timeScale = 1;
    }

    [Button]
    void PlayMusic()
    {

    }

    [Button]
    void PauseMusic()
    {

    }

    public void UpInput()
    {
        Debug.Log("Up");
        NotesManager.Instance.SpawnNoteNorth();
    }

    public void DownInput()
    {
        Debug.Log("Down");
        NotesManager.Instance.SpawnNoteSouth();
    }

    public void LeftInput()
    {
        Debug.Log("Left");
        NotesManager.Instance.SpawnNoteWest();
    }

    public void RightInput()
    {
        Debug.Log("Right");
        NotesManager.Instance.SpawnNoteEast();
    }
}