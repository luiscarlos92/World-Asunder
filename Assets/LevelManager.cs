using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject player;
	public GameObject companion;
	public Canvas hud;

	public bool paused = false;

	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(player);
		DontDestroyOnLoad(companion);
		DontDestroyOnLoad(hud);

		//Loads starting level
		SceneManager.LoadScene("Fort");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void loadCombatArena(string enemyName){
		//PlayerPrefs.SetString ("Enemy", enemyName);

	}
}
