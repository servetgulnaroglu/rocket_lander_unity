using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardChooser : MonoBehaviour
{
    [SerializeField] int rocketIndexOnBoard;
    private void OnMouseDown()
    {
        FindObjectOfType<CurrentRocketShower>().ChangeCurrentRocket(rocketIndexOnBoard);
    }
}
