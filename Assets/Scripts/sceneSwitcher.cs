using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour
{

    public GameObject panel;

    public void PauseGame()
    {
        Time.timeScale = 0;
        if (panel != null)
            panel.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        if (panel != null)
            panel.gameObject.SetActive(false);
    }
    public void GotoMainMenu()
    {
        scoreScript.ResetScore();
        SceneManager.LoadScene(0);
    }

    public void GotoLevel(int level)
    {
        if (level < 1) return;
        if (Time.timeScale == 0) Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        if ((Time.timeScale == 1) && (panel != null))
        {
            panel.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (panel != null))
        {
            if (scoreScript.livesCount == 0)
            {
                GotoMainMenu();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                panel.gameObject.SetActive(false);
            }
            else if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                panel.gameObject.SetActive(true);
            }
        }
    }
}
