using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{
    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GotoLevel(int level)
    {
        if (level < 1) return;
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
