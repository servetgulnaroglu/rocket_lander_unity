using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void setVolume(System.Single vol)
    {
        PlayerPrefs.SetFloat(General.Statics.VOLUME, vol);
        AudioListener.volume = vol;
        Debug.Log(PlayerPrefs.GetFloat(General.Statics.VOLUME));
    }
}
