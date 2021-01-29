using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] private CharacterController charCtrl;
	[SerializeField] private Transform groundCheck;
	[SerializeField] Camera vCam;

	float speed = 10.0f;
	public float gravity = -20f;
	
	public float groundDistance = .4f;
	public LayerMask groundMask;
	private bool isGrounded;

	public float jumpHeight = 2.0f;

	Vector3 velocity;
	Vector3 move = Vector3.zero;

	private static Player instance;
	public static Player Instance
    {
		get 
		{ 
			if (instance == null)
            {
				instance = FindObjectOfType<Player>();
            }
			return instance; 
		}
    }
    private void Awake()
    {
		if (instance == null)
        {
			instance = this;
		}

		if (instance != this)
        {
			Destroy(gameObject);
        }
    }

    void Start()
	{
		//hide the mouse
		Cursor.lockState = CursorLockMode.Locked;
		charCtrl = GetComponent<CharacterController>();
	}

	void Update()
	{
		Cursor.lockState = CursorLockMode.Locked;

		//make character model rotate with the camera
		var rot = vCam.transform.rotation;
		rot.x = 0;
		rot.z = 0;
		transform.rotation = rot;

		//running
		if (Input.GetButton("Fire3") == true)
		{
			Debug.Log("Running");
			speed = 20f;
		}
		else
		{
			speed = 10f;
		}

		//ground check
		isGrounded = (Physics.CheckBox(new Vector3(groundCheck.position.x - 1f, groundCheck.position.y, groundCheck.position.z), new Vector3(groundDistance, 0.1f, groundDistance), Quaternion.identity, groundMask) &&
				Physics.CheckBox(new Vector3(groundCheck.position.x, groundCheck.position.y, groundCheck.position.z - 1f), new Vector3(groundDistance, 0.1f, groundDistance), Quaternion.identity, groundMask) &&
				Physics.CheckBox(new Vector3(groundCheck.position.x + 1f, groundCheck.position.y, groundCheck.position.z), new Vector3(groundDistance, 0.1f, groundDistance), Quaternion.identity, groundMask) &&
				Physics.CheckBox(new Vector3(groundCheck.position.x, groundCheck.position.y, groundCheck.position.z + 1f), new Vector3(groundDistance, 0.1f, groundDistance), Quaternion.identity, groundMask));

		//reset gravity if grounded
		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}

		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");

		//movement
		move = transform.right * x + transform.forward * z;
		move.Normalize();
		charCtrl.Move(move * speed * Time.deltaTime);

		//gravity
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;

		charCtrl.Move(velocity * Time.deltaTime);
	}
}
