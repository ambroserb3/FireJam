﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	[SerializeField] private int m_MapSize;
	[SerializeField] private GameObject m_TilePrefab;
	public MapTile[,] grid;

	public GameObject[] TileList;

	// Use this for initialization
	void Awake () {
		grid = new MapTile[m_MapSize, m_MapSize];
		for(int i=0; i<m_MapSize; i++){
			for(int j=0; j<m_MapSize; j++){
				spawnTile(i,j);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void spawnTile(int x, int y){
		int n = Random.Range(0, TileList.Length);
		GameObject g = GameObject.Instantiate(TileList[n], new Vector3(x,y,0), Quaternion.identity, transform);
		MapTile tile = g.GetComponent<MapTile>();
		grid[x,y] = tile;
		tile.Init(x, y, grid);
	}
}
