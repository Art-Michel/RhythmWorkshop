using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using NaughtyAttributes;
using UnityEngine.Playables;

public class GameManager : LocalManager<GameManager>
{
    PlayableDirector _playableDirector;
    PreventLostFocus _preventLostFocus;

    private void Start()
    {
        Time.timeScale = 1;
        _playableDirector = GetComponent<PlayableDirector>();
        _preventLostFocus = GetComponent<PreventLostFocus>();
    }

    public void PlayMusic()
    {
        _playableDirector.Resume();
    }

    public void PauseMusic()
    {
        _playableDirector.Pause();
    }

    public void UpInput()
    {
        NotesManager.Instance.SpawnNoteNorth();
    }

    public void PreventLostFocus(bool b)
    {
        _preventLostFocus.enabled = b;
    }

    public void DownInput()
    {
        NotesManager.Instance.SpawnNoteSouth();
    }

    public void LeftInput()
    {
        NotesManager.Instance.SpawnNoteWest();
    }

    public void RightInput()
    {
        NotesManager.Instance.SpawnNoteEast();
    }
}