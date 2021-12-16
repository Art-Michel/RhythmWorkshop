using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    GameObject _fadeToBlack;

    void Awake()
    {
        _fadeToBlack = GameObject.FindWithTag("Find");
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Game()
    {
        SoundManager.Instance.PlayStartButton();
        Invoke("LoadGameScene", 1.5f);
        if (_fadeToBlack != null)
            _fadeToBlack.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("SceneArthur");
    }

    public void OnHover()
    {
        SoundManager.Instance.PlayButtonHilight();
    }
    public void Click()
    {
        SoundManager.Instance.PlayMenuClick();
    }

    public void CreditsHyperlink()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCwHQ93ecuoQne93sgY-x8Nw");
    }
}
