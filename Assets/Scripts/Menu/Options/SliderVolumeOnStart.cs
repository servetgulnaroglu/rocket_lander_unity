using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderVolumeOnStart : MonoBehaviour
{
    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat(General.Statics.VOLUME));
        if (PlayerPrefs.HasKey(General.Statics.VOLUME))
        {
            GetComponent<Slider>().value = PlayerPrefs.GetFloat(General.Statics.VOLUME);
        }

    }
}
