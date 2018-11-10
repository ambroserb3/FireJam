using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour {

	private MapTile[,] grid;

	void Awake () {
		grid = GameObject.FindWithTag("Map").GetComponent<Map>().grid;
	}

	
	void FixedUpdate() {
		int x = (int)(transform.position.x+0.5f);
		int y = (int)(transform.position.y+0.5f);
		grid[x,y].Ignite();
	}
}
