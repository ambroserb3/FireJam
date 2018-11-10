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
    public Waterspurt spurt;
    MapTile[,] grid;

    private float lastShotTime;

    private Vector2 lastMove;


    private void Awake() {
        grid = GameObject.FindWithTag("Map").GetComponent<Map>().grid;
        lastShotTime = Time.time;
        lastMove = new Vector2(0,1);
    }

    private void Update(){
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
            Waterspurt sput = Instantiate(spurt);
            sput.Init(transform.position, lastMove, grid);
            lastShotTime = currTime;
        }
    }

}	
