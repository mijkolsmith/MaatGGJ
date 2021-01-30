using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
	UNLOCKSTAIR,
	UNLOCKLIFT,
	UNLOCKJETPACK
}

public class InvestResource : MonoBehaviour
{
	[SerializeField] private int cost;
	[SerializeField] private EventType eventType;

	public void Invest()
	{
		if (GameManager.Instance.rm.RemoveResource(cost))
		{
			Unlock();
		}
	}

	void Unlock()
	{
		EventManager.RaiseEvent(eventType);
	}
}