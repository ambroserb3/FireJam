using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditions : MonoBehaviour {

    public int bluePlayerHealth;
    public int blueTowerHealth;

    public int redPlayerHealth;
    public int redTowerHealth;

    public bool gameFinished;
    public int winner;

	// Use this for initialization
	void Start () {
        //bluePlayerHealth = Constants.playerHealth;
        //redPlayerHealth = Constants.playerHealth;
        //blueTowerHealth = Constants.towerHealth;
        //redTowerHealth = Constants.towerHealth;

        gameFinished = false;
        winner = -1; //We can just set this to 0 for blue winner, red otherwise
	}


    void checkPlayers()
    {
        if (bluePlayerHealth == 0)
        {
            //respawn(bluePlayer); //TODO: This has not been implemented yet.
        }
        if (redPlayerHealth == 0)
        {
            //respawn(redPlayer); //TODO: Has not been implemented yet.
        }

    }

    void checkTowers()
    {
        if (redTowerHealth == 0)
        {
            gameFinished = true;
            winner = 0;
        }
        else if(blueTowerHealth == 0)
        {
            gameFinished = true;
            winner = 1;
        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
