using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBehaviour : MonoBehaviour
{
	Quaternion NorthRotation = Quaternion.Euler(0, -89, 0);
	Quaternion WestRotation = Quaternion.Euler(0, -179, 0);

	private bool north = false;
	private bool west = false;

	private float step = 10;

	private void Start()
    {
		EventManager.AddListener(EventType.UNLOCKSTAIRNORTH, GrowStairNorth);
		EventManager.AddListener(EventType.UNLOCKSTAIRWEST, GrowStairWest);
	}

	private void Update()
	{
		if (transform.rotation.y <= NorthRotation.y && north == true)
		{
			transform.RotateAround(transform.parent.position, Vector3.up, step * Time.deltaTime);
		}
		else if (transform.rotation.y >= NorthRotation.y && north == true)
		{
			north = false;
		}

		if (transform.rotation.y >= WestRotation.y && west == true)
		{
			transform.RotateAround(transform.parent.position, Vector3.up, -step * Time.deltaTime);
		}
		else if (transform.rotation.y <= WestRotation.y && west == true)
		{
			west = false;
		}
	}

	private void GrowStairNorth()
    {
		north = true;
		west = false;
		transform.GetChild(1).gameObject.SetActive(true);
    }

	private void GrowStairWest()
	{
		west = true;
		north = false;
		transform.GetChild(1).gameObject.SetActive(true);
	}
}