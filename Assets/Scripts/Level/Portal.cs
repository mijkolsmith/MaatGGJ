using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            activated = true;
            //other.gameObject.transform.position = destination.position;
        }
    }

    public bool IsActivated() => activated;
}
