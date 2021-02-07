using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRocketShower : MonoBehaviour
{
    [SerializeField] GameObject[] rockets;
    int currentRocketIndex;
    void Start()
    {
        if (PlayerPrefs.HasKey(General.Statics.CURRENT_ROCKET_INDEX))
        {
            currentRocketIndex = PlayerPrefs.GetInt(General.Statics.CURRENT_ROCKET_INDEX);
        }
        else
        {
            currentRocketIndex = 0;
        }
        rockets[currentRocketIndex].SetActive(true);
    }

    public void ChangeCurrentRocket(int indexToBeSwitched)
    {
        if (currentRocketIndex != indexToBeSwitched)
        {
            rockets[currentRocketIndex].GetComponent<Animator>().SetTrigger("OnGo");
            currentRocketIndex = indexToBeSwitched;
            PlayerPrefs.SetInt(General.Statics.CURRENT_ROCKET_INDEX, currentRocketIndex);
            rockets[currentRocketIndex].SetActive(true);
            rockets[currentRocketIndex].GetComponent<Animator>().Rebind();
            rockets[currentRocketIndex].GetComponent<Animator>().Update(0f);
        }
    }

    public void SetCurrentRocketIndex(int index)
    {
        currentRocketIndex = index;
    }
}
