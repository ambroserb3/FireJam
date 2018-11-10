using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {

    public GameObject FirePlayerPrefab;
    public GameObject WaterPlayerPrefab;

    // Use this for initialization
    void Start () {
        //Is this mine??
        if(isLocalPlayer == false)
        {
            //this object belongs to another player
            return;
        }

        //Since playerobject is invisible and not part of the world
        // give me something physical to move around

        Debug.Log("Spawned Unit");

        //Instantiate() only creates object on Local PC, even with netID
        //NetworkServer.Spawn() is the only way to spawn everywhere

        //Command Server to spawn  our unit
        CmdSpawnMyUnit();
	}
	
	// Update is called once per frame
	void Update () {
		//Runs on everyone computer regardless of ownership
	}

    //Commands -only exceuted on server
    [Command]
    void CmdSpawnMyUnit()
    {
        //on server
        GameObject go = Instantiate(FirePlayerPrefab);

        //now that object exists on server, send to the clients

        NetworkServer.Spawn(go);
    }
}
