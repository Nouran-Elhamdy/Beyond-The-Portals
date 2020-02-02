using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseScene()
    {

        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
    public void ResumeScene()
    {
        paused = !paused;

        if (!paused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
    public void OnRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
