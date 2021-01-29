using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
	public int resources { get { return resources; } private set { } }

	public void AddResource(int amount)
	{
		resources += amount;
	}

	public void RemoveResource(int amount)
	{
		resources -= amount;
	}
}