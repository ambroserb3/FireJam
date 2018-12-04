using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class FireBehavior : NetworkBehaviour {

	private MapTile tile;
	private MapTile[,] grid;
	private GameManager GM;

	public void Init(MapTile tile, MapTile[,] grid, GameManager GM){
		this.tile = tile;
		this.grid = grid;
		this.GM = GM;
		GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/flame");
        GetComponent<AudioSource>().Play();
	}

	void FixedUpdate(){
		GM.score += 2;
	}

	public void Extinguish(){
		tile.isLit = false;
		GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/extinguish");
        GetComponent<AudioSource>().Play();
		GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Destroy(gameObject, 0.5f);
	}
}
