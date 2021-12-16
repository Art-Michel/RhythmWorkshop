using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineLoop : MonoBehaviour
{
    PlayableDirector _playableDirector;

    void Start()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }
    public void Loop()
    {
        _playableDirector.time = 48.36875f;
    }
}
