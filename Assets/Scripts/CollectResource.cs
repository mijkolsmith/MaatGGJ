using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResource : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == Player.Instance.gameObject)
		{
			GameManager.Instance.rm.AddResource(1);
			Destroy(gameObject);
		}
	}
}