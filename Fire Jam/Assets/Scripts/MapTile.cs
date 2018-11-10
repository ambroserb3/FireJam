﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour {

    public GameObject FirePrefab;
    public float igniteTime;
    public int maxHealth; //how many spurts of water it needs to douse

    public bool isLit = false;
    public MapTile[,] grid;

    public GameManager GM;

    private int health;

    private int x;
    private int y;

	void Awake () {
	}
	

    public void Ignite(){
        if(!isLit){
            GameObject fire = GameObject.Instantiate(FirePrefab, transform.position, transform.rotation);
            fire.GetComponent<FireBehavior>().Init(this, grid);
            isLit = true;
        }
    }

    public void Init(int x, int y, MapTile[,] grid){
        this.x = x;
        this.y = y;
        this.grid = grid;
    }
}
