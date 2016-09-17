using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float updownRange = 60.0f; //60 degrees
	public float movementSpeed = 5.0f;
	public float jumpSpeed = 5.0f;

	float verticalRotation = 0;
	float verticalVelocity = 0;

	CharacterController characterController;


	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		//rotation

		CharacterController cc = GetComponent<CharacterController>(); //helps to interact with the game world


		float rotLeftRight = Input.GetAxis ("Mouse X")*3; //left right
		transform.Rotate (0, rotLeftRight, 0);

		/*float rotUpDown = Input.GetAxis ("Mouse Y")*3;
		float currentupdown = Camera.main.transform.rotation.eulerAngles.x;
		float desiredupdown = currentupdown - rotUpDown;

		desiredupdown = Mathf.Clamp (desiredupdown, -updownRange, updownRange);
		*/
		verticalRotation -= Input.GetAxis ("Mouse Y") * 3;
		verticalRotation = Mathf.Clamp (verticalRotation, -updownRange, updownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);

		//movement

		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		if (characterController.isGrounded && Input.GetButtonDown ("Jump")) {
			verticalVelocity = jumpSpeed;
		}



		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);

		speed = transform.rotation * speed; //rotate the speed to match the character rotatiion



		cc.Move( speed * Time.deltaTime ); //same distance in same amt of time for all pcs

		

	}
}
