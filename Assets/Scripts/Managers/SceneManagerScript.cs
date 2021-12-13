using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Game()
    {
        SceneManager.LoadScene("SceneArthur");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
