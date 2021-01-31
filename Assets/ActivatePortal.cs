using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePortal : MonoBehaviour
{
	[SerializeField] private Portal localPortal;
	[SerializeField] private Portal homePortal;
	float timer = 2f;
	bool exit = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == Player.Instance.gameObject)
		{
			homePortal.gameObject.SetActive(true);
			homePortal.linkedPortal = localPortal;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == Player.Instance.gameObject)
		{
			exit = true;
		}
	}

	private void Update()
	{
		timer -= Time.deltaTime;
		if (exit == true && timer < 1)
		{
			homePortal.gameObject.SetActive(false);
			timer = 2f;
			exit = false;
		}
	}
}
