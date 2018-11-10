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
        Vector2 directionW = new Vector2();
        directionW += new Vector2 (CrossPlatformInputManager.GetAxis("wHor"), 
                                   CrossPlatformInputManager.GetAxis("wVert"));

        Vector2 directionF = new Vector2();
        directionF += new Vector2(CrossPlatformInputManager.GetAxis("fHor"), 
                                  CrossPlatformInputManager.GetAxis("fVert"));

        // Pass all parameters to the character control script.
        if(directionW.magnitude > epsilon){
            m_Controller.MoveW(directionW.normalized);
        }

        if(directionF.magnitude > epsilon){
            m_Controller.MoveF(directionF.normalized);
        }

        if (Input.GetButton("Shoot")){
            m_Controller.Shoot();
        }
	}
}
