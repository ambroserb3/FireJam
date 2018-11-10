using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour {

	private PlayerController m_Controller;

    readonly float epsilon =.01f;

	private void Awake()
	{
		m_Controller = GetComponent<PlayerController>();
	}


	void Update()
	{
		// Read the inputs.
		Vector2 direction = new Vector2();
		if(CrossPlatformInputManager.GetButton("Left"))
			direction += new Vector2(-1,0);
		if(CrossPlatformInputManager.GetButton("Right"))
			direction += new Vector2(1,0);
		if(CrossPlatformInputManager.GetButton("Up"))
			direction += new Vector2(0,1);
		if(CrossPlatformInputManager.GetButton("Down"))
			direction += new Vector2(0,-1);
		// Pass all parameters to the character control script.
        if (direction.magnitude > epsilon){
            m_Controller.Move2(direction.normalized);
        }

        if (Input.GetButton("Shoot")){
            m_Controller.Shoot();
        }
	}
}
