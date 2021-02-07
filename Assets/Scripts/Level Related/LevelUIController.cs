using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIController : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject joystickCanvas;


    public void OnPauseButtonClicked()
    {
        StopTime();
        SetPauseGameCanvasActive();
    }

    public void OnResumeButtonClicked()
    {
        ResumeTime();
        SetPauseGameCanvasInactive();
    }

    public void OnMenuButtonClicked()
    {
        ResumeTime();
        LevelLoader.LoadMenu();
    }

    public void OnRestartButtonClicked()
    {
        ResumeTime();
        LevelLoader.LoadSameScene();
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void ResumeTime()
    {
        Time.timeScale = 1;
    }

    private void SetPauseGameCanvasActive()
    {
        menuCanvas.SetActive(true);
    }

    private void SetPauseGameCanvasInactive()
    {
        menuCanvas.SetActive(false);
    }

    public void OnRocketCollision()
    {
        joystickCanvas.SetActive(false);
    }

}
