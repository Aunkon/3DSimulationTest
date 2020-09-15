using UnityEngine;
using System.Collections;

public class CameraNavigation : MonoBehaviour
{
	//Simple flycam I made, since I couldn't find any others made public.
	//Made simple to use (drag and drop, done) for regular keyboard layout  
	//wasd : basic movement
	//shift : Makes camera accelerate
	//space : Moves camera on X and Z axis only.  So camera doesn't gain any height

	public float cameraSpeed = 7; //regular camera speed
	public float shiftAddSpeed = 20; //multiplied by how long shift is held.  Basically running
	public float maxShiftSpeed = 25; //Maximum speed when holdin gshift
	public float camSensivity = 0.15f; //How sensitive it with mouse
	public bool rotateOnlyIfMousedown = true;
	public bool movementStaysFlat = true;

	private Vector3 lastMouse = new Vector3();
	private float totalRun = 1.0f;

	void Update()
	{

		if (Input.GetMouseButtonDown(1))
		{
			lastMouse = Input.mousePosition;
		}

		if (!rotateOnlyIfMousedown || (rotateOnlyIfMousedown && Input.GetMouseButton(1)))
		{
			lastMouse = Input.mousePosition - lastMouse;
			lastMouse = new Vector3(-lastMouse.y * camSensivity, lastMouse.x * camSensivity, 0);
			lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
			transform.eulerAngles = lastMouse;
			lastMouse = Input.mousePosition;
			//Mouse  camera angle done.  
		}

		//Keyboard commands
		float f = 0.0f;
		Vector3 p = GetBaseInput();
		if (Input.GetKey(KeyCode.LeftShift))
		{
			totalRun += Time.deltaTime;
			p = p * totalRun * shiftAddSpeed;
			p.x = Mathf.Clamp(p.x, -maxShiftSpeed, maxShiftSpeed);
			p.y = Mathf.Clamp(p.y, -maxShiftSpeed, maxShiftSpeed);
			p.z = Mathf.Clamp(p.z, -maxShiftSpeed, maxShiftSpeed);
		}
		else
		{
			totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
			p = p * cameraSpeed;
		}

		p = p * Time.deltaTime;
		Vector3 newPosition = transform.position;
		if (Input.GetKey(KeyCode.Space)
			|| (movementStaysFlat && !(rotateOnlyIfMousedown && Input.GetMouseButton(1))))
		{ //If player wants to move on X and Z axis only
			transform.Translate(p);
			newPosition.x = transform.position.x;
			newPosition.z = transform.position.z;
			transform.position = newPosition;
		}
		else
		{
			transform.Translate(p);
		}

	}

	private Vector3 GetBaseInput()
	{ //returns the basic values, if it's 0 than it's not active.
		Vector3 p_Velocity = new Vector3();
		if (Input.GetKey(KeyCode.W))
		{
			p_Velocity += new Vector3(0, 0, 1);
		}
		if (Input.GetKey(KeyCode.S))
		{
			p_Velocity += new Vector3(0, 0, -1);
		}
		if (Input.GetKey(KeyCode.A))
		{
			p_Velocity += new Vector3(-1, 0, 0);
		}
		if (Input.GetKey(KeyCode.D))
		{
			p_Velocity += new Vector3(1, 0, 0);
		}
		return p_Velocity;
	}
}