using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	[SerializeField] private int m_MapSize;
	[SerializeField] private GameObject m_TilePrefab;
	private MapTile[,] grid;

	// Use this for initialization
	void Awake () {
		grid = new MapTile[m_MapSize, m_MapSize];
		for(int i=0; i<m_MapSize; i++){
			for(int j=0; j<m_MapSize; j++){
				grid[i,j] = GameObject.Instantiate(m_TilePrefab, new Vector3(i,j,0), Quaternion.identity).GetComponent<MapTile>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void spawnTile(int x, int y){
		GameObject g = GameObject.Instantiate(m_TilePrefab, new Vector3(x,y,0), Quaternion.identity);
		MapTile tile = g.GetComponent<MapTile>();
		grid[x,y] = tile;
		tile.Init(x, y, grid);
	}
}
