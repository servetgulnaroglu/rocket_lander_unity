using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class VcamMoveBack : MonoBehaviour
{
    [SerializeField] float backMoveValue = 25f;
    public void moveBackCamera()
    {
        CinemachineComponentBase componentBase = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent(CinemachineCore.Stage.Body);
        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = backMoveValue;
        }
    }
}
