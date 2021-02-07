using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestResource : MonoBehaviour
{
	[SerializeField] private int cost;
	public int Cost { get { return cost; } private set { cost = value; } }
	[SerializeField] private EventType eventType;

	public void Invest()
	{
		if (GameManager.Instance.rm.RemoveResource(Cost))
		{
			Unlock();
			Cost = 0;
		}
	}

	void Unlock()
	{
		if(Cost>0) AudioManager.Instance.PlayMusic(AudioType.MUSIC_UNLOCK);
		EventManager.RaiseEvent(eventType);
	}
}