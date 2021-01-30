using UnityEngine;
using UnityEngine.SceneManagement;

public class LiftBehaviour : MonoBehaviour
{
	[SerializeField] private GameObject leftDoor;
	[SerializeField] private GameObject rightDoor;
	[SerializeField] private Transform leftDoorGoal;
	[SerializeField] private Transform rightDoorGoal;

	private bool opening = false;
	private bool raising = false;
	private float step = 20;

	private void Start()
	{
		EventManager.AddListener(EventType.UNLOCKLIFT, OpenLift);
		EventManager.AddListener(EventType.UNLOCKNEXTLEVEL, RaiseLift);
	}

	private void Update()
	{
		if (opening == true)
		{
			leftDoor.transform.position = Vector3.MoveTowards(leftDoor.transform.position, leftDoorGoal.position, step * Time.deltaTime);
			rightDoor.transform.position = Vector3.MoveTowards(rightDoor.transform.position, rightDoorGoal.position, step * Time.deltaTime);
		}
		if (raising == true)
		{
			step += 0.02f;
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 1000, transform.position.z), step * Time.deltaTime);
			if (transform.position.y > 750)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
		else if (raising == false && transform.position.y < 0)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, transform.position.z), step * Time.deltaTime);
			if (transform.position.y > -25)
			{
				step -= 0.0175f;
			}
		}
		else if (raising == false)
		{
			StopRaisingLift();
		}
	}

	private void OpenLift()
	{
		step = 1;
		opening = true;
	}

	private void RaiseLift()
	{
		step = 1;
		Player.Instance.transform.SetParent(transform);
		Player.Instance.charCtrl.enabled = false;
		raising = true;
	}

	private void StopRaisingLift()
	{
		step = 1;
		Player.Instance.transform.parent = null;
		Player.Instance.charCtrl.enabled = true;
	}
}