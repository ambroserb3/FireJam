using System.Collections;
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
