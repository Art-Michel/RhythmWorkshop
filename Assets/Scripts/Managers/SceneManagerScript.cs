using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    [SerializeField] GameObject _fadeToBlack;
    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Game()
    {
        SoundManager.Instance.PlayStartButton();
        _fadeToBlack.SetActive(true);
        Invoke("LoadGameScene", 1.5f);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void LoadGameScene()
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
