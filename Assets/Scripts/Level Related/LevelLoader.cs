using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextIndexScene = currentScene + 1;
        if (SceneManager.sceneCountInBuildSettings == nextIndexScene)
        {
            nextIndexScene = 0;
        }
        SceneManager.LoadScene(nextIndexScene);
    }

    public static void LoadSameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}

