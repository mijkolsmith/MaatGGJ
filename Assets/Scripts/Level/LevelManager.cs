using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Portal[] portals;
    public GameObject[] lights;
    public Material onMaterial;

    private int numActivated;

    private bool[] lightsOn;
    public bool this[int i]
    {
        set
        {
            if (!lightsOn[i] && value)
            {
                // turn on light
                lights[i].GetComponent<Renderer>().material = onMaterial;

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
