using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject WaterPlayerPrefab;
	public GameObject FirePlayerPrefab;

    public Image pane1;
    public Image pane2;
    public Text winText;

    public int AvgNumFires;
	public int NumFires;
	public int WinThreshold;
	public int score;
	Slider scoreboard;

	void Awake () {
		GameObject.Instantiate(WaterPlayerPrefab);
		GameObject.Instantiate(FirePlayerPrefab);
		scoreboard = GetComponentInChildren<Slider>();
		scoreboard.maxValue = WinThreshold;
		scoreboard.minValue = -WinThreshold;
		score = 0;
	}
	void FixedUpdate () {
		score -= AvgNumFires;
		scoreboard.value = score;
		if(score >= WinThreshold){
			// fire wins
            pane1.enabled = true;
            pane2.enabled = true;
            winText.text = "Fireperson  Wins!!";
            Time.timeScale = 0;
		}
		else if (score <= -WinThreshold){
            // water wins
            pane1.enabled = true;
            pane2.enabled = true;
            winText.text = "Waterperson  Wins!!";
            winText.color = Color.blue;
            Time.timeScale = 0;
		}
	}
}
