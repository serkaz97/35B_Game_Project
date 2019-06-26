using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider trigger)
    {
        GameManager.Instance.SetNewCheckpoint(this);
    }

    private void OnTriggerExit(Collider trigger)
    {
        GameManager.Instance.SetNewCheckpoint(this);
    }
}
