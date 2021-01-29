using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool used = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            used = true;
            //other.gameObject.transform.position = destination.position;
        }
    }

    public bool IsUsed() => used;
}
