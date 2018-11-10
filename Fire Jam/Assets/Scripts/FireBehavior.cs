using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour {

	private MapTile tile;
	private MapTile[,] grid;

	public int SpreadFreq = 1;
	private float SpreadRate;

	IEnumerator Spread(){
		while(true){
			foreach(MapTile t in tile.GetAdjacent()){
				if(!t.isLit){
					t.Burn();
				}
			}
			yield return new WaitForSeconds(SpreadRate);
		}
	}

	public void Init(MapTile tile, MapTile[,] grid){
		this.tile = tile;
		this.grid = grid;

		SpreadRate = 1f/SpreadFreq;
		StartCoroutine(Spread());

		GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/flame");
        GetComponent<AudioSource>().Play();
	}

	public void Extinguish(){
		StopAllCoroutines();
		tile.isLit = false;
		GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/extinguish");
        GetComponent<AudioSource>().Play();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag.Equals("Spurt")){
			Debug.Log("Boom!");
		}
	}
}
