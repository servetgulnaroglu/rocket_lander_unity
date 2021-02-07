using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        // int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);
        // Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        Debug.Log("asdfasdf");
        // print(collisionEvents.Count);
        // int i = 0;
        // while (i < numCollisionEvents)
        // {
        //     if (rigidbody)
        //     {
        //         Vector3 pos = collisionEvents[i].intersection;
        //         Vector3 force = collisionEvents[i].velocity * 10;
        //         rigidbody.AddForce(force);
        //     }
        // }
    }
}
