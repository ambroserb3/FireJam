using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject WaterPlayerPrefab;
	public GameObject FirePlayerPrefab;

	public int AvgNumFires;
	public int NumFires;
	public int WinThreshold;
	public static int score;
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
			Time.timeScale = 0;
		}
		else if (score <= -WinThreshold){
			// water wins
			Time.timeScale = 0;
		}
	}
}
