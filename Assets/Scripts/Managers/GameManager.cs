using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

		//StartCoroutine(SkipLevel1());
	}

	IEnumerator SkipLevel1()
	{
		yield return new WaitForSeconds(1.0f);
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			EventManager.RaiseEvent(EventType.UNLOCK_NEXT_LEVEL);
		}
	}
	
}
