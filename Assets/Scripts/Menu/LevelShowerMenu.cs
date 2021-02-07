using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelShowerMenu : MonoBehaviour
{
    int latestLevelIndex;
    int choosenIndex;
    void Start()
    {
        Data data = SaveDataToSystem.LoadData();
        if (data == null)
        {
            latestLevelIndex = 0;
        }
        else
        {
            latestLevelIndex = data.GetLatestLevel();
        }
        choosenIndex = latestLevelIndex;
        int i = 0;
        foreach (Transform child in transform)
        {
            if (i > latestLevelIndex)
            {
                child.gameObject.GetComponent<Toggle>().interactable = false;
            }
            i++;
        }
        GameObject latestLevelButton = gameObject.transform.GetChild(choosenIndex).gameObject;
        latestLevelButton.GetComponent<Toggle>().isOn = true;
        SetColorsOfChoosenIndex(choosenIndex);
    }

    public void SetChoosenIndex(int index)
    {
        ResetColorsOfPreviousChoosen(choosenIndex);
        choosenIndex = index;
        SetColorsOfChoosenIndex(choosenIndex);
    }

    public void StartChoosenLevel()
    {
        SceneManager.LoadScene(choosenIndex + 1); // +1 to exclude menu scene
    }

    private void SetColorsOfChoosenIndex(int index)
    {
        GameObject latestLevelButton = gameObject.transform.GetChild(index).gameObject;
        var colors = latestLevelButton.GetComponent<Toggle>().colors;
        ColorUtility.TryParseHtmlString("#628C60", out Color normalColor);
        colors.normalColor = normalColor;
        latestLevelButton.GetComponent<Toggle>().colors = colors;
    }

    private void ResetColorsOfPreviousChoosen(int prev)
    {
        GameObject previousChoosenLevel = gameObject.transform.GetChild(prev).gameObject;
        var colors = previousChoosenLevel.GetComponent<Toggle>().colors;
        colors.normalColor = Color.white;
        previousChoosenLevel.GetComponent<Toggle>().colors = colors;
        // Destroy(previousChoosenLevel.GetComponent<Button>());
        // previousChoosenLevel.AddComponent<Button>();
    }


}
