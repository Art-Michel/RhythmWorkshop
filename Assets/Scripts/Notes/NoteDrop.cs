using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDrop : MonoBehaviour
{
    [SerializeField] NotesManager notesManager;
    [SerializeField] List<int> noteList = new List<int>();
    int a;
    int i;
    [SerializeField] float bpm;
    public bool boomHp;
    public float maxRate;
    float beatTime;


    void Update()
    {
        maxRate = 60 / bpm;
        beatTime += Time.deltaTime;

        if (beatTime >= maxRate)
        {
            if (boomHp == true)
            {
                OnTheBeat();
            }

            beatTime -= maxRate;
        }
    }

    public void StartBeat()
    {
        boomHp = true;
    }

    public void StopBeat()
    {
        boomHp = false;
    }

    public void OnTheBeat()
    {
        switch (noteList[a])
        {
            case 1:
                notesManager.SpawnNoteNorth();
                a++;
                break;
            case 2:
                notesManager.SpawnNoteSouth();
                a++;
                break;
            case 3:
                notesManager.SpawnNoteEast();
                a++;
                break;
            case 4:
                notesManager.SpawnNoteWest();
                a++;
                break;
        }
    }
}
