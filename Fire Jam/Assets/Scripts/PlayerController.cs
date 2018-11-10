using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] public float m_MaxSpeed;                    // The fastest the player can travel.
	[SerializeField] public float m_Accel;
	[SerializeField] public float m_Decel;

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
		// Decellerate faster than accelerate
		float newX = m_Rigidbody2D.velocity.x+move.x;
		if( Mathf.Abs(newX) > Mathf.Abs(m_Rigidbody2D.velocity.x) )
			move.x*=m_Accel;
		else
			move.x*=m_Decel;

		float newY = m_Rigidbody2D.velocity.y+move.y;
		if( Mathf.Abs(newY) > Mathf.Abs(m_Rigidbody2D.velocity.y) )
			move.y*=m_Accel;
		else
			move.y*=m_Decel;

		m_Rigidbody2D.AddForce(move);

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
