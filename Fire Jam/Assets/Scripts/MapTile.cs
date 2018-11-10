<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour {

	public MapTile[,] m_grid;
	public int m_x;
	public int m_y;

	public void Init(int x, int y, MapTile[,] grid){
		m_x = x;
		m_y = y;
		m_grid = grid;
	}

	// Use this for initialization
	public List<MapTile> GetAdjacent(){
		List<MapTile> res = new List<MapTile>();
		if(m_x>0)
			res.Add(m_grid[m_x-1, m_y]);
		if(m_y>0)
			res.Add(m_grid[m_x, m_y-1]);
		if(m_x<m_grid.GetUpperBound(0))
			res.Add(m_grid[m_x+1, m_y]);
		if(m_y<m_grid.GetUpperBound(1));
			res.Add(m_grid[m_x, m_y+1]);
		return res;
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour {

    public Sprite img;
    public Sprite fireImg;
    public float igniteTime;
    public int maxHealth; //how many spurts of water it needs to douse

    public GameManager GM;

    private int health;

    private int x;
    private int y;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = img;
        transform.localScale = Constants.sizeScale * transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (GM.fPosX == x && GM.fPosY == y){
            print("firesperson is in:" + x + ", " + y);
        }
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

    public void SetPos(int x, int y){
        this.x = x;
        this.y = y;
    }
}
>>>>>>> d3b65dd587470221b4b00f02ae882e7cbb257a8f
