using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class PlayerInput : NetworkBehaviour {

	private PlayerController m_Controller;

    readonly float epsilon =.01f;

	private void Awake()
	{
		m_Controller = GetComponent<PlayerController>();
	}


	void Update()
	{

        //Is this mine??
        if (isLocalPlayer == false)
        {
            //this object belongs to another player
            return;
        }

        // Read the inputs.
        Vector2 directionW = new Vector2();
            directionW += new Vector2(CrossPlatformInputManager.GetAxis("wHor"),
                                       CrossPlatformInputManager.GetAxis("wVert"));

            // Pass all parameters to the character control script.
            if (directionW.magnitude > epsilon)
            {
                m_Controller.MoveW(directionW.normalized);
            }
        
        
            Vector2 directionF = new Vector2();
            directionF += new Vector2(CrossPlatformInputManager.GetAxis("fHor"),
                                      CrossPlatformInputManager.GetAxis("fVert"));

            if (directionF.magnitude > epsilon)
            {
                m_Controller.MoveF(directionF.normalized);

            }
        
	}
}
