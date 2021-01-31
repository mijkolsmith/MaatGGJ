using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResource : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == Player.Instance.gameObject)
		{
			AudioManager.Instance.pickupSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
			AudioManager.Instance.PlaySFX(AudioType.SFX_PICKUP);
			GameManager.Instance.rm.AddResource(1);
			Destroy(gameObject);
		}
	}
}