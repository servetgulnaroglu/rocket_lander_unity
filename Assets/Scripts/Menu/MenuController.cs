using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    Vector3 initialPosition;
    Animator animator;
    Animator sceneCameraAnimator;

    void Start()
    {
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
        sceneCameraAnimator = FindObjectOfType<Camera>().GetComponent<Animator>();
        if (sceneCameraAnimator == null)
        {
            Debug.LogError("Camera don't have animator");
        }
    }

    public void OnStartButtonClicked()
    {
        print("Start Button");
        animator.SetTrigger("MainMenuToLevels");
        sceneCameraAnimator.SetTrigger("MainMenuToRocket");
    }

    public void OnOptionsButtonClicked()
    {
        animator.SetTrigger("MainMenuToOptions");
        sceneCameraAnimator.SetTrigger("MainMenuToOptions");
    }

    public void OnRocketsButtonClicked()
    {
        animator.SetTrigger("MainMenuToRocket");
        sceneCameraAnimator.SetTrigger("MainMenuToRocket");
    }

    public void OnBackToMainMenuButtonClickedInLevels()
    {
        animator.SetTrigger("LevelsToMainMenu");
        sceneCameraAnimator.SetTrigger("RocketToMainMenu");
    }

    public void OnBackToMainMenuButtonClickedInRockets()
    {
        animator.SetTrigger("RocketToMainMenu");
        sceneCameraAnimator.SetTrigger("RocketToMainMenu");
    }

    public void OnBackToMainButtonClickedInOptions()
    {
        animator.SetTrigger("OptionsToMainMenu");
        sceneCameraAnimator.SetTrigger("OptionsToMainMenu");
    }

    public void SetTransformToMainMenu()
    {
        transform.position = initialPosition;
    }
}

