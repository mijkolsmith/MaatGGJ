using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool activated = false;
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            activated = true;
            //other.gameObject.transform.position = destination.position;
            Player.Instance.transform.SetPositionAndRotation(destination.position, destination.rotation);
        }
    }
    public bool IsActivated() => activated;
}
