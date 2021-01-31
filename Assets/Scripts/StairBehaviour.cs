using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBehaviour : MonoBehaviour
{
	Quaternion NorthRotation = Quaternion.Euler(0, -89, 0);
	Quaternion WestRotation = Quaternion.Euler(0, -179, 0);

	private bool north = false;
	private bool west = false;

	Quaternion startRotation;

	private float step = 14.45f;

	private bool isRotating = false;
	private bool IsRotating
	{
		set
		{
			if (!isRotating && value)
			{

				AudioManager.Instance.PlaySFX(AudioType.SFX_STAIRS_TURN);
			}

			isRotating = value;
		}
	}

	private void Start()
	{
		EventManager.AddListener(EventType.UNLOCK_STAIR_NORTH, GrowStairNorth);
		EventManager.AddListener(EventType.UNLOCK_STAIR_WEST, GrowStairWest);
	}

	private void Update()
	{
		if (transform.parent != null)
		{
			if (transform.rotation.y <= NorthRotation.y && north == true)
			{
				transform.RotateAround(transform.parent.position, Vector3.up, step * Time.deltaTime);
				AudioManager.Instance.stairsTurningSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
				IsRotating = true;
			}
			else if (transform.rotation.y >= NorthRotation.y && north == true)
			{
				north = false;
				IsRotating = false;
				if (startRotation != NorthRotation)
				{
					AudioManager.Instance.StopMusic(AudioType.SFX_STAIRS_TURN);
				}
			}

			if (transform.rotation.y >= WestRotation.y && west == true)
			{
				transform.RotateAround(transform.parent.position, Vector3.up, -step * Time.deltaTime);
				AudioManager.Instance.stairsTurningSFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
				IsRotating = true;
			}
			else if (transform.rotation.y <= WestRotation.y && west == true)
			{
				west = false;
				IsRotating = false;
				if (startRotation != NorthRotation)
				{
					AudioManager.Instance.StopMusic(AudioType.SFX_STAIRS_TURN);
				}
				AudioManager.Instance.StopSFX(AudioType.SFX_STAIRS_TURN);
			}
		}
	}

	private void GrowStairNorth()
	{
		if (transform.rotation.y >= NorthRotation.y)
		{
			startRotation = WestRotation;
		}
		north = true;
		west = false;
		transform.GetChild(1).gameObject.SetActive(true);
	}

	private void GrowStairWest()
	{
		if (transform.rotation.y >= WestRotation.y)
		{
			startRotation = NorthRotation;
		}

		west = true;
		north = false;
		transform.GetChild(1).gameObject.SetActive(true);
	}
}