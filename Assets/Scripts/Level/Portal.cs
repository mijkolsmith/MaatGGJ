using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool used = false;
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player.Instance.gameObject)
        {
            used = true;
            Player.Instance.transform.SetPositionAndRotation(destination.position, destination.rotation);
        }
    }

    public bool IsUsed() => used;
}
