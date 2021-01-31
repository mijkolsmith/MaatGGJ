using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapWallTeleport : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == Player.Instance.gameObject)
		{
			if (Player.Instance.transform.position.x > 490)
			{
				Player.Instance.transform.position =
					new Vector3(Player.Instance.transform.position.x - 975, Player.Instance.transform.position.y, Player.Instance.transform.position.z);
			}
			if (Player.Instance.transform.position.x < -490)
			{
				Player.Instance.transform.position =
					new Vector3(Player.Instance.transform.position.x + 975, Player.Instance.transform.position.y, Player.Instance.transform.position.z);
			}
			if (Player.Instance.transform.position.z > 490)
			{
				Player.Instance.transform.position =
					new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y, Player.Instance.transform.position.z - 975);
			}
			if (Player.Instance.transform.position.z < -490)
			{
				Player.Instance.transform.position =
					new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y, Player.Instance.transform.position.z + 975);
			}
		}
	}
}