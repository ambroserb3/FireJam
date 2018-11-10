using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    [SerializeField] public int m_MapSize;
    [SerializeField] public GameObject m_TilePrefab;

    public MapTile[] tileList;

	private MapTile[,] grid;

	// Use this for initialization
	void Awake () {
		grid = new MapTile[m_MapSize, m_MapSize];
		for(int i=0; i<m_MapSize; i++){
			for(int j=0; j<m_MapSize; j++){
                int x = Random.Range(0, tileList.Length);
                grid[i,j] = Instantiate(tileList[x], new Vector3(i,j,0), Quaternion.identity).GetComponent<MapTile>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
