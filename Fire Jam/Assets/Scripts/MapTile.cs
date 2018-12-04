﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class MapTile : MonoBehaviour {

    [SerializeField] private float spreadTimer;

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
    public MapTile ppos;
    public GameObject player;


    void Start () {
        fireHealth = igniteTime;
        spreadTimer = 5;
        GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

    private void Update()
    {
        player = GameObject.Find("FirePlayer(Clone)");

        PlayerController Pcontrol = player.GetComponent<PlayerController>();

        if (Pcontrol.isWater == false)
        {
            int x = (int)(player.transform.position.x + 0.5f);
            int y = (int)(player.transform.position.y + 0.5f);
            ppos = grid[x, y];
        }

        spreadTimer -= Time.deltaTime;
        foreach (MapTile t in grid)
        {
            if (t.isLit && spreadTimer < 0)
            {
                t.Spread();
                spreadTimer = 2;
            }
        }
    }


    public void Burn(){
        if(!isLit){
            Debug.Log("spreading");
            Ignite();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spurt" && grid[x,y].isLit == true)
               {
                  grid[x, y].Wet();
                  Destroy(col.gameObject);
               }
    }

            public void Spread(){
        foreach(MapTile t in ppos.Adjacent){
            if(!t.isLit){
                //t.Burn();
                fireHealth -= 1;
                if (fireHealth <= 0)
                {
                    fireHealth = igniteTime;
                }

                int x = (int)(t.transform.position.x + 0.5f);
                int y = (int)(t.transform.position.y + 0.5f);
                grid[x, y].Ignite();
                //Ignite();
                //Debug.Log("ignite called at " + t.x + " and "  + t.y);
            }
        }
    }
    public void Ignite(){
        if (!isLit){
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
        if (x < grid.GetUpperBound(0))
            Adjacent.Add(grid[x + 1, y]);
        if (x > 0)
            Adjacent.Add(grid[x - 1, y]);
        if (y < grid.GetUpperBound(1))
            Adjacent.Add(grid[x, y + 1]);
		if(y>0)
			Adjacent.Add(grid[x, y-1]);
    }
}
