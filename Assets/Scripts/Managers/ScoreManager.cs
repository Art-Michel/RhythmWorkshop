using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : LocalManager<ScoreManager>
{
    [SerializeField] GameObject _gameOverUiParent;
    [SerializeField] TextMeshProUGUI _gameOverResults;
    [SerializeField] TextMeshProUGUI _scoreUI;
    [SerializeField] TextMeshProUGUI _comboUI;

    float _missedNotes = 0;
    float _goodedNotes = 0;
    float _perfectedNotes = 0;
    float _score;
    float _currentCombo;
    float _longestCombo;

    void Start()
    {
        _currentCombo = 0;
        _longestCombo = 0;
        _score = 0;
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
    }

    public void DisplayGameOverScreen()
    {
        _gameOverUiParent.SetActive(true);
        _gameOverResults.text =(
            "Misses: " + _missedNotes + "\n"
            +"Goods: " + _goodedNotes + "\n"
            +"Perfects: " + _perfectedNotes + "\n"
            +"Longest Combo: " + _longestCombo
        );
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
