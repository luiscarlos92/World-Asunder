using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject player;
	public GameObject companion;
	public Canvas hud;

	public bool paused = false;
	public string lastScene = "Load";
	public string currentScene = "Load";

	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(player);
		DontDestroyOnLoad(companion);
		DontDestroyOnLoad(hud);

		//Loads starting level
		loadScene("Fort");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void loadCombatArena(string enemyName){
		if(enemyName.Equals("Poss"))
			GameObject.Find ("Cell Door").SetActive (false);

		PlayerPrefs.SetString ("Enemy", enemyName);
		GameObject.FindWithTag("Player").SetActive(false);
		GameObject.FindWithTag("Companion").SetActive(false);
		SceneManager.LoadScene("CombatArena");
	}

	public void loadScene(string sceneName ){
		paused = false;
		lastScene = currentScene;
		currentScene = sceneName;
		SceneManager.LoadScene(sceneName);


	}
		
}
