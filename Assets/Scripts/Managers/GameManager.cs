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
    }

    public void DownInput()
    {
        Debug.Log("Down");
    }

    public void LeftInput()
    {
        Debug.Log("Left");
    }

    public void RightInput()
    {
        Debug.Log("Right");
    }
}