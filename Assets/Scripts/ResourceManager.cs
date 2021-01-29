using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
	private int resources;
	public int Resources { get => resources; private set => resources = value; }

	public void AddResource(int amount)
	{
		Resources += amount;
	}

	public bool RemoveResource(int amount)
	{
		if (Resources >= amount)
		{
			Resources -= amount;
			return true;
		}
		return false;
	}
}