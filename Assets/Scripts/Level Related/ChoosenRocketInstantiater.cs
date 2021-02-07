using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChoosenRocketInstantiater : MonoBehaviour
{
    [SerializeField] GameObject[] rockets;
    void Start()
    {
        int currentRocketIndex = 0;
        if (PlayerPrefs.HasKey(General.Statics.CURRENT_ROCKET_INDEX))
        {
            currentRocketIndex = PlayerPrefs.GetInt(General.Statics.CURRENT_ROCKET_INDEX);
        }
        GameObject rocket = Instantiate(rockets[currentRocketIndex], transform.position, transform.rotation) as GameObject;
        FindObjectOfType<CinemachineVirtualCamera>().Follow = rocket.transform;
    }
}
