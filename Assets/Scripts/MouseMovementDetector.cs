using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementDetector : MonoBehaviour {
	public bool MouseHover;
	public float ScrollSpeed;
	// Use this for initialization
	void Start () {
		MouseHover = false;
		ScrollSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseEnter()
	{

		MouseHover = true;

		if (this.gameObject.name == "Up" || this.gameObject.name == "Right")
			ScrollSpeed = .2f;
		else 
			ScrollSpeed = -.2f;
			

	}
	public void OnMouseExit()
	{
		MouseHover = false;

		ScrollSpeed = 0;

	}
}
