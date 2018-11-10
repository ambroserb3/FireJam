using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterspurt : MonoBehaviour {

    public float speed;
    private Vector3 vel;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(vel * Time.deltaTime, Space.World);
    }

    public void SetDir(Vector2 move){
        vel = speed * move;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, vel);
    }
}
