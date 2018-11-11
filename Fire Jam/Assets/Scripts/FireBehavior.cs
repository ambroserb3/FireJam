using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour {

	private MapTile tile;
	private MapTile[,] grid;

	public float SpreadFreq = 1;
	private float SpreadRate;


	public void Init(MapTile tile, MapTile[,] grid){
		this.tile = tile;
		this.grid = grid;

		GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/flame");
        GetComponent<AudioSource>().Play();
	}

	void FixedUpdate(){
		GameManager.score++;
	}

	public void Extinguish(){
		tile.isLit = false;
		GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/extinguish");
        GetComponent<AudioSource>().Play();
		GetComponent<SpriteRenderer>().enabled = false;
		GameObject.Destroy(gameObject, 0.5f);
	}
}
