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
                Debug.Log(Player.Instance);
                // player singleton
                // bring player to destination
                Player.Instance.transform.position = destination.position;

                numActivated++;
                if (numActivated == portals.Length)
                {
                    // UnlockAscend();
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
