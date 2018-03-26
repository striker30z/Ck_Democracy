using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float speed;
	public int zoomSpeed;
	GameObject TopHover;
	GameObject BotHover;
	GameObject RightHover;
	GameObject LeftHover;
	GameObject WorldLimit;
	GameObject TopLeftHover;
	GameObject TopRightHover;
	GameObject BotRightHover;
	GameObject BotLeftHover;
	// Use this for initialization
	void Start () {
		speed = 1;
		zoomSpeed = 10;
		TopHover = GameObject.Find ("Up");
		BotHover = GameObject.Find ("Down");
		RightHover = GameObject.Find ("Right");
		LeftHover = GameObject.Find ("Left");
		WorldLimit = GameObject.Find ("WorldLimit");
		TopLeftHover = GameObject.Find ("TopLeft");
		TopRightHover = GameObject.Find ("TopRight");
		BotRightHover = GameObject.Find ("BotRight");
		BotLeftHover = GameObject.Find ("BotLeft");
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += new Vector3(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical"), 0);
		if (TopLeftHover.GetComponent<MouseMovementDetector> ().MouseHover || TopRightHover.GetComponent<MouseMovementDetector> ().MouseHover || BotRightHover.GetComponent<MouseMovementDetector> ().MouseHover || BotLeftHover.GetComponent<MouseMovementDetector> ().MouseHover) {
			if (TopRightHover.GetComponent<MouseMovementDetector> ().MouseHover)
				transform.position += new Vector3 (speed * .2f, speed * .2f, 0);
			if (TopLeftHover.GetComponent<MouseMovementDetector> ().MouseHover)
				transform.position += new Vector3 (speed * -.2f, speed * .2f, 0);
			if (BotRightHover.GetComponent<MouseMovementDetector> ().MouseHover)
				transform.position += new Vector3 (speed * .2f, speed * -.2f, 0);
			if (BotLeftHover.GetComponent<MouseMovementDetector> ().MouseHover)
				transform.position += new Vector3 (speed * -.2f, speed * -.2f, 0);
		} else {
			if (TopHover.GetComponent<MouseMovementDetector> ().MouseHover || RightHover.GetComponent<MouseMovementDetector> ().MouseHover)
				transform.position += new Vector3 (speed * RightHover.GetComponent<MouseMovementDetector> ().ScrollSpeed, speed * TopHover.GetComponent<MouseMovementDetector> ().ScrollSpeed, 0);

			if (BotHover.GetComponent<MouseMovementDetector> ().MouseHover || LeftHover.GetComponent<MouseMovementDetector> ().MouseHover)
				transform.position += new Vector3 (speed * LeftHover.GetComponent<MouseMovementDetector> ().ScrollSpeed, speed * BotHover.GetComponent<MouseMovementDetector> ().ScrollSpeed, 0);
		}

		if(Mathf.Abs(this.gameObject.transform.position.z - WorldLimit.transform.position.z) > 5f && Mathf.Abs(Input.GetAxis ("Mouse ScrollWheel")) > 0 )
			transform.position += new Vector3(0, 0, zoomSpeed * Input.GetAxis ("Mouse ScrollWheel"));
		else if(Input.GetAxis ("Mouse ScrollWheel") < 0)
			transform.position += new Vector3(0, 0, zoomSpeed * Input.GetAxis ("Mouse ScrollWheel"));
		Debug.Log (Input.GetAxis ("Mouse ScrollWheel").ToString ());
	}
}
