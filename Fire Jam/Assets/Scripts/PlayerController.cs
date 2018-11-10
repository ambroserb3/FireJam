using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel.
	[SerializeField] private float m_Accel = .1f;

	private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.

	private void Awake()
	{
		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}


	private void FixedUpdate()
	{
	}


	public void Move(Vector2 move)
	{
		// Move the character
		m_Rigidbody2D.AddForce(move*m_Accel);
		if(m_Rigidbody2D.velocity.magnitude > m_MaxSpeed){
			m_Rigidbody2D.velocity = m_Rigidbody2D.velocity.normalized*m_MaxSpeed;
		}

	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}	
