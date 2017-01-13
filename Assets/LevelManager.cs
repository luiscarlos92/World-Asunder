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

	public Dictionary<string,bool> events;

	public bool paused = false;
	public string lastScene = "Load";
	public string currentScene = "Load";
	public string enemy = "";

	public string choosenCompanion = "Coelestine";
	public string choosenSpace = "Coelestine";
	public string choosenQ = "Coelestine";
	public string choosenW = "Coelestine";
	public string choosenE = "Coelestine";
	public string choosenR = "Coelestine";

	Vector2 savedPlayer;
	Vector2 savedCompanion;

	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(player);
		DontDestroyOnLoad(companion);
		DontDestroyOnLoad(hud);

		initializeEvents ();

		//Loads starting level
		loadScene("Fort");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void initializeEvents(){
		events = new Dictionary<string, bool> ();
		events.Add ("Started", true);
		events.Add ("Previously", true);
		events.Add ("GuardA", false);
		events.Add ("GuardB", false);
		events.Add ("Sing", false);
		events.Add ("Poss", false);
		events.Add ("PossFight", false);
		events.Add ("PossCutscene", false);


	}

	public void loadCombatArena(string enemyName){
		if (enemyName.Equals ("Poss"))
			GameObject.Find ("Cell Door").SetActive (false);

		//PlayerPrefs.SetString ("Enemy", enemyName);
		enemy = enemyName;
		savePositions ();
		player.SetActive(false);
		companion.SetActive(false);
		SceneManager.LoadScene("CombatArena");
	}

	public void returnCombatArena(){
		if (enemy.Equals ("Poss")) {
			abilitiesHUD.GetComponent<AbilitiesUIController> ().abilitiesPoss.enabled = true;
			events ["PossFight"] = true;
		}

		loadScene(currentScene);
		player.SetActive(true);
		companion.SetActive(true);
	}

	public void loadScene(string sceneName ){
		
		paused = false;
		lastScene = currentScene;
		currentScene = sceneName;
		SceneManager.LoadScene(sceneName);

	}

	public void savePositions (){
		savedPlayer = player.transform.position;
		savedCompanion = companion.transform.position;
	}

	public void restorePositions(){
		player.transform.position = savedPlayer;
		companion.transform.position = savedCompanion;
	}

	public void restartGame(){
		if(currentScene.Equals("Cell")){
			lastScene = "Load";
			currentScene = "Fort";
			paused = false;
			enemy = "";
			SceneManager.LoadScene(currentScene);
			player.SetActive(true);
			companion.SetActive(true);
		}
		initializeEvents ();
	}

	public void setPlayer(){

		if (enemy.Equals ("")) {

			if (currentScene.Equals ("Fort")) {
				if (lastScene.Equals ("Cell")) {
					player.transform.position = GameObject.Find ("FortStairs").transform.position;
					companion.transform.position = GameObject.Find ("FortStairsC").transform.position;
				}

				if (lastScene.Equals ("Load") || lastScene.Equals ("Beach")) {
					player.transform.position = GameObject.Find ("FortSpawn").transform.position;
					companion.transform.position = GameObject.Find ("FortSpawnC").transform.position;
				}
			}

			if (currentScene.Equals ("Cell")) {
				if (lastScene.Equals ("Fort")) {
					player.transform.position = GameObject.Find ("CellSpawn").transform.position;
					companion.transform.position = GameObject.Find ("CellSpawnC").transform.position;
				}
			}

			if (currentScene.Equals ("Beach")) {
				if (lastScene.Equals ("Fort")) {
				}
			}
		} else {
			restorePositions ();
			enemy = "";
		}
	}
}
