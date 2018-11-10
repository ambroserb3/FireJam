using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour {

	private PlayerController m_Controller;

	private void Awake()
	{
		m_Controller = GetComponent<PlayerController>();
	}


	private void Update()
	{

	}


	private void FixedUpdate()
	{
		// Read the inputs.
		Vector2 direction = new Vector2();
		if(CrossPlatformInputManager.GetButton("left"))
			direction += new Vector2(-1,0);
		if(CrossPlatformInputManager.GetButton("right"))
			direction += new Vector2(1,0);
		if(CrossPlatformInputManager.GetButton("up"))
			direction += new Vector2(0,1);
		if(CrossPlatformInputManager.GetButton("down"))
			direction += new Vector2(0,-1);
		// Pass all parameters to the character control script.
		m_Controller.Move(direction.normalized);
	}
}
