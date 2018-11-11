﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour {

    public GameObject FirePrefab;
    public int igniteTime;
    public bool isLit = false;
    public MapTile[,] grid;
    public int spin;

    public List<MapTile> Adjacent;
    private int fireHealth;

    private int x;
    private int y;

    private GameManager GM;

	void Start () {
        fireHealth = igniteTime;
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

    public void Burn(){
        if(!isLit){
            fireHealth-=1;
            if(fireHealth<=0){
                Ignite();
                fireHealth = igniteTime;
            }
        }
    }

    public void Spread(){
        foreach(MapTile t in Adjacent){
            if(!t.isLit){
                t.Burn();
            }
        }
    }
    public void Ignite(){
        if(!isLit){
            GameObject fire = GameObject.Instantiate(FirePrefab, transform.position, transform.rotation, transform);
            fire.GetComponent<FireBehavior>().Init(this, grid, GM);
            fire.transform.Rotate(new Vector3(0,0,1), -spin*90);
            isLit = true;
        }
    }

    public void Init(int x, int y, MapTile[,] grid){
        this.x = x;
        this.y = y;
        this.grid = grid;
    }

    public void Wet(){
        gameObject.GetComponentInChildren<FireBehavior>().Extinguish();
        fireHealth = igniteTime;
    }

    public void SetAdjacent(){
        Adjacent = new List<MapTile>();
		if(x>0)
			Adjacent.Add(grid[x-1, y]);
		if(y>0)
			Adjacent.Add(grid[x, y-1]);
		if(x<grid.GetUpperBound(0))
			Adjacent.Add(grid[x+1, y]);
		if(y<grid.GetUpperBound(1))
			Adjacent.Add(grid[x, y+1]);
    }
}
