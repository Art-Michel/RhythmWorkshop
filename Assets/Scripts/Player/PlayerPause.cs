using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerPause : MonoBehaviour
{

    [SerializeField] GameObject _pauseUI;
    [SerializeField] GameObject _pauseFirstButtonSelected;
    PlayerActionMap _inputs;
    bool _isPaused = false;

    private void Awake()
    {
        _inputs = new PlayerActionMap();
        _inputs.Movement.Start.started += PressStart;
    }

    public void PressStart(InputAction.CallbackContext ctx)
    {
        if (!_isPaused)
            Pause();
        else if (_isPaused)
            Unpause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GameManager.Instance.PauseMusic();
        SoundManager.Instance.PlayPause();
        _isPaused = true;
        _pauseUI.SetActive(true);
        GameManager.Instance.PreventLostFocus(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_pauseFirstButtonSelected);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        GameManager.Instance.PlayMusic();
        _isPaused = false;
        GameManager.Instance.PreventLostFocus(false);
        _pauseUI.SetActive(false);
    }

    private void OnEnable()
    {
        _inputs.Enable();
    }
    private void OnDisable()
    {
        _inputs.Disable();
    }
}
