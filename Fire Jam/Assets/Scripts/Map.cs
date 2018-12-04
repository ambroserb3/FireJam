﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Map : NetworkBehaviour {

    [SerializeField] private int m_MapSize;
	[SerializeField] private GameObject m_TilePrefab;
	public MapTile[,] grid;
	public GameObject[] TileList;
    public bool mapGenerated = false;
    [SerializeField] private float spreadTimer;
    public GameObject GM;


    // Use this for initialization
    void Awake () {

    }

    private void Update()
    {
        //if (mapGenerated == false)
        //{
        //    RpcMapGen();
        //}
    }

    public void MapGenButton()
    {
        CmdServerGen();

        //RpcMapGen();
        GM = GameObject.FindGameObjectWithTag("GameController");
        GameManager gM = GM.GetComponent<GameManager>();
        gM.RpcWaterSelection();
    }


    private void spawnTile(int x, int y){
		int n = Random.Range(0, TileList.Length);
		GameObject g = GameObject.Instantiate(TileList[n], new Vector3(x,y,0), Quaternion.identity, transform);
        int spin = Random.Range(0, 4);
        MapTile tile = g.GetComponent<MapTile>();
		grid[x,y] = tile;
        grid[x,y].transform.Rotate(new Vector3(0,0,1), 90*spin);
        grid[x,y].spin = spin;
		tile.Init(x, y, grid);
	}



    [Command]
    public void CmdServerGen()
    {
        //grid = new MapTile[m_MapSize, m_MapSize];
        //for (int i = 0; i < m_MapSize; i++)
        //{
        //    for (int j = 0; j < m_MapSize; j++)
        //    {
        //        spawnTile(i, j);
        //    }
        //}

        //foreach (MapTile t in grid)
        //{
        //    t.SetAdjacent();
        //}
        RpcMapGen();
    }

    [ClientRpc]
    void RpcMapGen()
    {
        grid = new MapTile[m_MapSize, m_MapSize];
        for (int i = 0; i < m_MapSize; i++)
        {
            for (int j = 0; j < m_MapSize; j++)
            {
                spawnTile(i, j);
            }
        }

        foreach (MapTile t in grid)
        {
            t.SetAdjacent();
        }
        mapGenerated = true;
    }
}
