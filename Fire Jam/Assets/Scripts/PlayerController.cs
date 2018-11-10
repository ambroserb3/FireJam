using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] public float m_MaxSpeed;                    // The fastest the player can travel.
	[SerializeField] public float m_Accel;
	[SerializeField] public float m_Decel;

    public GameManager GM;

    public float bulletSpeed;
    public float bulletOfteness;
    public bool isWater;
    public waterspurt spurt;

    private float lastShotTime;

    private Vector2 lastMove;

    private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.

	private void Awake()
	{
		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

    private void Start() {
        lastShotTime = Time.time;
        lastMove = new Vector2(0,1);
    }

    private void Update(){
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


    public void MoveW(Vector2 move){
        if (isWater){
            transform.rotation = Quaternion.LookRotation(Vector3.forward, move);
            transform.Translate(move * m_MaxSpeed * Time.deltaTime, Space.World);
            lastMove = move;
        }
    }


    public void MoveF(Vector2 move) {
        if(!isWater) {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, move);
            transform.Translate(move * m_MaxSpeed * Time.deltaTime, Space.World);
        }
    }



    public void Shoot(){
        float currTime = Time.time;
        if (currTime-lastShotTime> bulletOfteness && isWater){
            waterspurt sput = Instantiate(spurt);
            sput.transform.position = transform.position;
            sput.SetDir(lastMove);
            lastShotTime = currTime;
        }
    }

}	
