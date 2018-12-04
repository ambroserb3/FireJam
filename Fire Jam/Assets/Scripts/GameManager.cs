using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Animations;


public class GameManager : NetworkBehaviour {

	public GameObject WaterPlayerPrefab;
	public GameObject FirePlayerPrefab;

    public Image pane1;
    public Image pane2;
    public Text winText;

    public Image SelectPane;
    public Image SelectPane2;
    public Button fireb;
    public Button waterb;
    public Text select;


    [SyncVar] public int AvgNumFires;
    [SyncVar] public int NumFires;
    [SyncVar] public int WinThreshold;
	[SyncVar] public int score;
	Slider scoreboard;
    public Sprite waterSprite;
    public RuntimeAnimatorController anim2;



    public void Awake () {
        SelectPane.enabled = false;
        SelectPane2.enabled = false;
        select.enabled = false;
        fireb.enabled = false;
        waterb.enabled = false;
        fireb.image.enabled = false;
        waterb.image.enabled = false;


        ////Is this mine??
        if (isLocalPlayer == false)
        {
            //this object belongs to another player
            return;
        }

        SelectPane.enabled = false;
        SelectPane2.enabled = false;
        select.enabled = false;
        fireb.enabled = false;
        waterb.enabled = false;
        fireb.image.enabled = false;
        waterb.image.enabled = false;

    }
    public void Update()
    {
    }

    [ClientRpc]
    void Rpcwaterboy()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        var pcontroller = player.GetComponent<PlayerController>();

        if (pcontroller.isWater == true)
        {
            SelectPane.enabled = false;
            SelectPane2.enabled = false;
            select.enabled = false;
            fireb.enabled = false;
            waterb.enabled = false;
            fireb.image.enabled = false;
            waterb.image.enabled = false;
        }
    }
    [ClientRpc]
    public void RpcWaterSelection()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        var pcontroller = player.GetComponent<PlayerController>();
        player.GetComponent<Animator>().runtimeAnimatorController = anim2 as RuntimeAnimatorController;
        pcontroller.isWater = true;
        var fspawner = player.GetComponent<FireSpawner>();
        fspawner.enabled = false;
        player.name = "WaterPlayer";
        player.tag = "WaterPlayer";


        Rpcwaterboy();

    }
    [ClientRpc]
    public void RpcFireSelection()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        var pcontroller = player.GetComponent<PlayerController>();
        var fspawner = player.GetComponent<FireSpawner>();
        fspawner.enabled = true;
        player.tag = "";


        pcontroller.isWater = false;
        SelectPane.enabled = false;
        SelectPane2.enabled = false;
        select.enabled = false;
        fireb.enabled = false;
        waterb.enabled = false;
        fireb.image.enabled = false;
        waterb.image.enabled = false;

    }

    [Command]
    void CmdScoreInit()
    {
        if (isServer) {
            RpcScoreInitialize();
        }
        else
        {
            scoreboard = GetComponentInChildren<Slider>();
            scoreboard.maxValue = WinThreshold;
            scoreboard.minValue = -WinThreshold;
            score = 0;
        }
    }
    [ClientRpc]
    void RpcScoreInitialize()
    {
        scoreboard = GetComponentInChildren<Slider>();
        scoreboard.maxValue = WinThreshold;
        scoreboard.minValue = -WinThreshold;
        score = 0;
    }

    [Command]
    private void CmdScoreCheck()
    {
        if (isServer)
        {
            RpcScoreCheck();
        }
        else
        {
            if (scoreboard != null)
            {
                score -= AvgNumFires;
                scoreboard.value = score;
                if (score >= WinThreshold)
                {
                    // fire wins
                    pane1.enabled = true;
                    pane2.enabled = true;
                    winText.text = "Fireperson  Wins!!";
                    Time.timeScale = 0;
                }
                else if (score <= -WinThreshold)
                {
                    // water wins
                    pane1.enabled = true;
                    pane2.enabled = true;
                    winText.text = "Waterperson  Wins!!";
                    winText.color = Color.blue;
                    Time.timeScale = 0;
                }
            }
            else
            {
                RpcScoreInitialize();
            }
        }
        //CODE GOES HERE TO EXECUTE THE PROCESS ON THE SERVER.
    }

    [ClientRpc]     //CODE GOES HERE TO EXECUTE THE PROCESS ON ALL CLIENTS
    void RpcScoreCheck()
    {
        if (scoreboard != null)
        {
            score -= AvgNumFires;
            scoreboard.value = score;
            if (score >= WinThreshold)
            {
                // fire wins
                pane1.enabled = true;
                pane2.enabled = true;
                winText.text = "Fireperson  Wins!!";
                Time.timeScale = 0;
            }
            else if (score <= -WinThreshold)
            {
                // water wins
                pane1.enabled = true;
                pane2.enabled = true;
                winText.text = "Waterperson  Wins!!";
                winText.color = Color.blue;
                Time.timeScale = 0;
            }
        }
        else
        {
            RpcScoreInitialize();
        }

    }

    void FixedUpdate () {
        CmdScoreCheck();
	}
}
