using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class DestroyedRocket : MonoBehaviour
{

    [SerializeField] ParticleSystem deathParticleSystem;
    [SerializeField] float explosionPower = 1000f;

    void Start()
    {
        // CinemachineVirtualCamera vcam = FindObjectOfType<CinemachineVirtualCamera>();
        // if (vcam != null)
        // {
        //     vcam.Follow = transform;
        // }
        foreach (Transform child in gameObject.transform)
        {
            Rigidbody childRigidbody = child.GetComponent<Rigidbody>();
            if (childRigidbody != null)
            {
                childRigidbody.velocity += new Vector3(Random.Range(-6f, 6f), explosionPower, -5f);
            }
        }
        //GetComponent<AudioSource>().PlayOneShot(explosionSound);

        deathParticleSystem.Play();
    }

    void Update()
    {

    }
}
