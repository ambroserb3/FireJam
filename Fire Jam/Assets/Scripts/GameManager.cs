using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject WaterPlayerPrefab;
	public GameObject FirePlayerPrefab;

	// Use this for initialization
	void Start () {
		GameObject.Instantiate(WaterPlayerPrefab);
		GameObject.Instantiate(FirePlayerPrefab);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
