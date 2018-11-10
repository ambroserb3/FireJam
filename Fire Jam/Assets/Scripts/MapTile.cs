﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour {

    public GameObject FirePrefab;
    public int igniteTime;
    public int extinguishHP; //how many spurts of water it needs to douse

    public bool isLit = false;
    public MapTile[,] grid;

    public GameManager GM;

    private int waterHealth;
    private int fireHealth;

    private int x;
    private int y;

	void Awake () {
        waterHealth = extinguishHP;
        fireHealth = igniteTime;
	}

    public void Burn(){
        fireHealth-=1;
        if(fireHealth==0)
            Ignite();
    }

    public void Ignite(){
        if(!isLit){
            GameObject fire = GameObject.Instantiate(FirePrefab, transform.position, transform.rotation, transform);
            fire.GetComponent<FireBehavior>().Init(this, grid);
            isLit = true;
        }
    }

    public void Init(int x, int y, MapTile[,] grid){
        this.x = x;
        this.y = y;
        this.grid = grid;
    }

    public List<MapTile> GetAdjacent(){
		List<MapTile> res = new List<MapTile>();
		if(x>0)
			res.Add(grid[x-1, y]);
		if(y>0)
			res.Add(grid[x, y-1]);
		if(x<grid.GetUpperBound(0))
			res.Add(grid[x+1, y]);
		if(y<grid.GetUpperBound(1))
			res.Add(grid[x, y+1]);
		return res;
	}
}
