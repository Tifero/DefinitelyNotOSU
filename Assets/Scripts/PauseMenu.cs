using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenuUi;

    private void Start()
    {
        pausemenuUi.SetActive(false);
    }

    private void Update()
    {
        GetButtonPause();
    }

    private void GetButtonPause()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (Manager.CanPlay)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        Manager.CanPlay = false;
        pausemenuUi.SetActive(true);
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        Manager.CanPlay = true;
        pausemenuUi.SetActive(false);
    }

    public void ResumePlayButton()
    {
        Resume();
    }
}