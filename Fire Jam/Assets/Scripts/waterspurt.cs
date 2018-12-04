using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Waterspurt : NetworkBehaviour {

    [SyncVar]public float speed;
    [SyncVar]private Vector3 vel;
//    public MapTile[,] grid;
    [SyncVar]private int oldX;
    [SyncVar]private int oldY;
    private float timer;
    private MapTile wpos;

    private void Awake()
    {
        timer = 3;
    }
    // Use this for initialization
    public void Init (Vector3 position, Vector2 direction, MapTile[,] grid) {
        transform.position = position;
        SetDir(direction);
        this.grid = grid;
    }

    private MapTile tile;
    private MapTile[,] grid;
    private GameManager GM;

    public void Init(MapTile tile, MapTile[,] grid, GameManager GM)
    {
        this.tile = tile;
        this.grid = grid;
        this.GM = GM;
    }

    void Update () {
      
        
        timer -= Time.deltaTime;
        transform.Translate(vel * Time.deltaTime, Space.World);

        int x = (int)(transform.position.x + 0.5f);
        int y = (int)(transform.position.y + 0.5f);
        //wpos = grid[x, y];
        if (x != oldX || y != oldY)
        {
            oldX = x;
            oldY = y;
            //x < 0 || y < 0 || x > grid.GetUpperBound(0) || y > grid.GetUpperBound(1)
            if (timer < 0)
            {
                GameObject.Destroy(gameObject);
                timer = 3;
            }
            //else if (wpos.isLit)
            //{
            //    grid[x, y].Wet();
            //    GameObject.Destroy(gameObject);
            //}
        }
    }

    //private void OnCollisionEnter2D(Collision2D c)
    //{
    //    if (c.gameObject.tag == "fire")
    //    {
    //        Destroy(c.gameObject);
    //    }
    //}

    public void SetDir(Vector2 move){
        vel = speed * move;
        vel = Quaternion.AngleAxis(Random.Range(-15,15), Vector3.forward) * vel;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, vel);
    }

}
