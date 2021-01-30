using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	private static GameManager instance = null;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<GameManager>();
			}
			return instance;
		}
	}

	public ResourceManager rm;
	public Player player;

	private void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		rm = new ResourceManager();
		player = Player.Instance;
	}

	private void Update()
	{
		
	}
}
