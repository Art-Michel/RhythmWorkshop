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
    void Update()
    {
        if (_playableDirector.time > 145.88f)
        {
            _playableDirector.time = 48.36875f;
        }
    }
}
