using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] GameObject destructedVersion;

    public void Bomb()
    {
        Instantiate(destructedVersion, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
