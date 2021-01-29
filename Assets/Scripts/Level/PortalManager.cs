using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Portal[] portals;
    public GameObject[] lights;
    public Material onMaterial;

    public Transform destination;
    private int numActivated;

    private bool[] lightsOn;
    public bool this[int i]
    {
        set
        {
            if (!lightsOn[i] && value)
            {
                // turn on light
                lightsOn[i] = value;
                lights[i].GetComponent<Renderer>().material = onMaterial;
                Player.Instance.transform.SetPositionAndRotation(destination.position, destination.rotation);

                numActivated++;
                if (numActivated == portals.Length)
                {
                    // UnlockAscend();
                    Debug.Log("all portals activated");
                }
            }
        }
    }


    private void Awake()
    {
        lightsOn = new bool[portals.Length];
    }


    private void Update()
    {
        for(int i=0; i<portals.Length; i++)
        {

            if (portals[i].IsActivated())
            {
                this[i] = true;

            }
        }
    }

}
