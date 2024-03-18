using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject controlsPage;

    private void Start()
    {
        controlsPage.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ControlsPage()
    {
        controlsPage.SetActive(true);
    }

    public void Back()
    {
        controlsPage.SetActive(false);
    }

    public void QuitFromStart()
    {
        Application.Quit();
    }
}
