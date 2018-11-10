<<<<<<< HEAD
﻿using System.Collections;
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
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    [SerializeField] public int m_MapSize;
    [SerializeField] public GameObject m_TilePrefab;

    public GameManager GM;

    public MapTile[] tileList;

	private MapTile[,] grid;

    // Use this for initialization
    private void Awake() {

    }

    void Start() {
		grid = new MapTile[m_MapSize, m_MapSize];
		for(int i=0; i<m_MapSize; i++){
			for(int j=0; j<m_MapSize; j++){
                int x = Random.Range(0, tileList.Length);
                grid[i,j] = Instantiate(tileList[x], new Vector3(i,j,0), Quaternion.identity).GetComponent<MapTile>();
                grid[i,j].SetPos(i,j);
                grid[i,j].GM = GM;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
>>>>>>> d3b65dd587470221b4b00f02ae882e7cbb257a8f
