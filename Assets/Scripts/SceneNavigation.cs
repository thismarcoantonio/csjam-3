using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public GameObject credits;

    public void NavigateToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ToggleCredits()
    {
        credits.SetActive(!credits.activeSelf);
    }
}
