using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] AudioClip successSound;
    [SerializeField] GameObject successCanvas;
    [SerializeField] GameObject explosionCanvas;

    public void PlaySuccessSound()
    {
        AudioSource.PlayClipAtPoint(successSound, Camera.main.transform.position);
    }


    public void LoadNextLevel()
    {
        LevelLoader.LoadNextLevel();
    }

    public void SaveDataToSystemOnSuccess()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int currentLevel = currentScene - 1;
        int nextLevel = currentLevel + 1;
        Data oldData = SaveDataToSystem.LoadData();
        if (oldData == null)
        {
            Data data = new Data();
            data.SetLatestLevel(nextLevel);
            SaveDataToSystem.SaveData(data);
        }
        else if (oldData.GetLatestLevel() <= nextLevel)
        {
            oldData.SetLatestLevel(nextLevel);
            SaveDataToSystem.SaveData(oldData);
        }
    }

    public void ShowSuccessCanvas()
    {
        successCanvas.SetActive(true);
    }

    public void ShowExplosionCanvas()
    {
        explosionCanvas.SetActive(true);
    }
}
