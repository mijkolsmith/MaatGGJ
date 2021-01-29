using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestResource : MonoBehaviour
{
	[SerializeField] private int cost;

	public void Invest()
	{
		if (GameManager.Instance.rm.RemoveResource(cost))
		{
			Debug.Log("Success!");
			//unlock
		}
	}
}