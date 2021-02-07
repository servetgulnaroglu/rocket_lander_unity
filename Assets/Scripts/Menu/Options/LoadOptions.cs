using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOptions : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey(General.Statics.VOLUME))
        {
            AudioListener.volume = PlayerPrefs.GetFloat(General.Statics.VOLUME);
        }
    }
}
