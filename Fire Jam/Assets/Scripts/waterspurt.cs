using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterspurt : MonoBehaviour {

    public float speed;
    private Vector3 vel;
    public MapTile[,] grid;
    private int oldX;
    private int oldY;


	// Use this for initialization
	public void Init (Vector3 position, Vector2 direction, MapTile[,] grid) {
        transform.position = position;
        SetDir(direction);
        this.grid = grid;
    }
    void Update () {
        transform.Translate(vel * Time.deltaTime, Space.World);
        int x = (int)(transform.position.x+0.5f);
		int y = (int)(transform.position.y+0.5f);
        if(x != oldX || y!= oldY){
            oldX = x;
            oldY = y;
            if(x<0 || y<0 || x>grid.GetUpperBound(0) || y>grid.GetUpperBound(1)){
                GameObject.Destroy(gameObject);
            }
            else if(grid[x,y].isLit){
		        grid[x,y].Wet();
                GameObject.Destroy(gameObject);
            }
        }
    }

    public void SetDir(Vector2 move){
        vel = speed * move;
        vel = Quaternion.AngleAxis(Random.Range(-15,15), Vector3.forward) * vel;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, vel);
    }

}
