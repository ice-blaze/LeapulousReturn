using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	Camera cam;

	public float speed = 10.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float lookSpeed = 150.0F;

	private Vector3 moveDirection = Vector3.zero;

	float oldValue = 0;

	// Use this for initialization
	void Start () {
		cam = GetComponentInParent<OVRCameraRig>().rightEyeCamera;
	}
	
	// Update is called once per frame
	void Update () {
		float mouseRotation = Input.GetAxis("Mouse X")*lookSpeed*Time.deltaTime;
		transform.Rotate(0,mouseRotation,0);

//		transform.forward = cam.transform.forward;

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

	}
}
