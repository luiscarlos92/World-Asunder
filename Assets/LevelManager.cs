using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject player;
	public GameObject companion;
	public Canvas hud;

	public Canvas dialogHUD;
	public Canvas abilitiesHUD;

	public bool paused = false;
	public string lastScene = "Load";
	public string currentScene = "Load";
	public string enemy = "";

	public string choosenCompanion = "Coelestine";
	public string choosenSpace = "Poss";
	public string choosenQ = "Poss";
	public string choosenW = "Poss";
	public string choosenE = "Poss";
	public string choosenR = "Poss";

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
		if (enemyName.Equals ("Poss"))
			GameObject.Find ("Cell Door").SetActive (false);

		//PlayerPrefs.SetString ("Enemy", enemyName);
		enemy = enemyName;
		player.SetActive(false);
		companion.SetActive(false);
		SceneManager.LoadScene("CombatArena");
	}

	public void returnCombatArena(){
		if (enemy.Equals ("Poss"))
			abilitiesHUD.GetComponent<AbilitiesUIController> ().abilitiesPoss.enabled = true;

		enemy = "";
		SceneManager.LoadScene(currentScene);
		player.SetActive(true);
		companion.SetActive(true);
	}

	public void loadScene(string sceneName ){
		
		paused = false;
		lastScene = currentScene;
		currentScene = sceneName;
		SceneManager.LoadScene(sceneName);


	}
		
}
