﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour {

    public Sprite img;
    public Sprite fireImg;
    public float igniteTime;
    public int maxHealth; //how many spurts of water it needs to douse

    public MapTile[,] grid;

    public GameManager GM;

    private int health;

    private int x;
    private int y;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = img;
        transform.localScale = Constants.sizeScale * transform.localScale;
	}
	

    private void Ignite(){
        GetComponent<SpriteRenderer>().sprite = fireImg;
        GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/flame");
        GetComponent<AudioSource>().Play();
    }

    private void Douse() {
        GetComponent<SpriteRenderer>().sprite = img;
        GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/extinguish");
        GetComponent<AudioSource>().Play();
    }

    public void Init(int x, int y, MapTile[,] grid){
        this.x = x;
        this.y = y;
        this.grid = grid;
    }
}
