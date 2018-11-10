using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour {
    public GameObject splashmanager;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(splashmanager);
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
	}
}
