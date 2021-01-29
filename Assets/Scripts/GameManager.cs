using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	internal static GameManager instance = null;

	private void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
			return;
		}
	}

	private void Update()
	{
		
	}
}
