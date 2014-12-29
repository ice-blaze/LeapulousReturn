using UnityEngine;
using System.Collections;

public class CameraAlignement : MonoBehaviour {

	OVRCameraRig parentCamera;
	Vector3 v = new Vector3(280,180,0);

	// Use this for initialization
	void Start () {
		parentCamera = GetComponentInParent<OVRCameraRig>();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.DrawRay (transform.position, parentCamera.rightEyeCamera.transform.forward, Color.blue);
//		Camera cam = GetComponentInParent<Camera>();
//		transform.position = parentCamera.centerEyeAnchor.forward;
		transform.forward = parentCamera.rightEyeCamera.transform.forward;

		transform.Rotate(v);
//		Debug.Log(parentCamera.centerEyeAnchor.forward);
	}
}
