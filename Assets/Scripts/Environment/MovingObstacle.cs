using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingObstacle : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    [SerializeField] int direction = 1;
    [Range(0, 1)] [SerializeField] float movementFactor;
    [Range(0, 1)] [SerializeField] float startPos = 0f;
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period + startPos;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(tau * cycles);
        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector * direction;
        transform.position = startingPos + offset;
    }
}
