using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour {

	private MapTile[,] grid;

	public int SpreadFreq = 1;
	private float SpreadRate;

	void Awake () {
		grid = GameObject.FindWithTag("Map").GetComponent<Map>().grid;
		SpreadRate = 1f/SpreadFreq;
		StartCoroutine(Spread());
	}

	
	IEnumerator Spread(){
		while(true){
			int x = (int)(transform.position.x+0.5f);
			int y = (int)(transform.position.y+0.5f);
			grid[x,y].Burn();
			yield return new WaitForSeconds(SpreadRate);
		}
	}
}
