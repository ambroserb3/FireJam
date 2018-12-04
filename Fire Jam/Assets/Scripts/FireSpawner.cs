using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FireSpawner : NetworkBehaviour {

	private MapTile[,] grid;

	void Start () {
	}

	
	void FixedUpdate() { 
        //CmdFireSpew();
    }

    [ClientRpc]
    public void RpcFireSpew()
    {
        grid = GameObject.Find("Map").GetComponent<Map>().grid;

        int x = (int)(transform.position.x + 0.5f);
        int y = (int)(transform.position.y + 0.5f);
        grid[x, y].Ignite();
    }

    [Command]
    public void CmdFireSpew()
    {
        RpcFireSpew();
        //grid = GameObject.Find("Map").GetComponent<Map>().grid;

        //int x = (int)(transform.position.x + 0.5f);
        //int y = (int)(transform.position.y + 0.5f);
        //grid[x, y].Ignite();
    }
}
