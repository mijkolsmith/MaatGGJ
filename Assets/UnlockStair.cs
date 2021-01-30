using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockStair : MonoBehaviour
{
    private void Start()
    {
		EventManager.AddListener(EventType.UNLOCKSTAIR, GrowStair);
	}

    private void GrowStair()
    {
		transform.GetChild(1).gameObject.SetActive(true);
    }
}