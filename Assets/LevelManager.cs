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
	public Canvas cutsceneHUD;
	public Canvas startHUD;
	public Canvas buttonsHUD;
	public Canvas storyHUD;

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

	public GameObject hallawayPrefab;
	public GameObject childPrefab;
	public GameObject adamastorPrefab;


	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(player);
		DontDestroyOnLoad(companion);
		DontDestroyOnLoad(hud);

		initializeEvents ();

		buttonsHUD.enabled = false;
		storyHUD.enabled = false;
		paused = true;
		//Loads starting level
		loadScene("Fort");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space") && startHUD.isActiveAndEnabled) {
			events ["Started"] = true;
			startHUD.enabled = false;
			buttonsHUD.enabled = true;
		} else
		if (Input.GetKeyDown ("space") && buttonsHUD.isActiveAndEnabled) {
			events ["Buttons"] = true;
			buttonsHUD.enabled = false;
			storyHUD.enabled = true;
		} else
		if (Input.GetKeyDown ("space") && storyHUD.isActiveAndEnabled) {
			events ["Previously"] = true;
			storyHUD.enabled = false;
			paused = false;
		}

		Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
		UIController ui = (UIController)canvas.GetComponent (typeof(UIController)); 
		if (events ["PossCutscene"] && !events ["PreHallaway"]) {
			
			ui.addToQueue ("Hecte:\"...\"");
			ui.addToQueue ("Hecte:\"I’m sorry. For your men.\"");
			ui.addToQueue ("Prisoner:\"I respect that. The name’s Poss, by the way.\"");

			ui.addToQueue ("#trigger:Action:Hallaway");
			events ["PreHallaway"] = true;
		}

	}

	void initializeEvents(){
		events = new Dictionary<string, bool> ();
		events.Add ("Started", false);
		events.Add ("Buttons", false);
		events.Add ("Previously", false);
		events.Add ("GuardA", false);
		events.Add ("GuardB", false);
		events.Add ("Sing", false);
		events.Add ("Poss", false);
		events.Add ("PossFight", false);
		events.Add ("PossCutscene", false);
		events.Add ("PreHallaway", false);
		events.Add ("HallawayFight", false);
		events.Add ("GoOutside", false);
		events.Add ("ChildASpawn", false);
		events.Add ("ChildAFight", false);

	}

	void initializeStrings(){
		  choosenCompanion = "Coelestine";
		  choosenSpace = "Coelestine";
		  choosenQ = "Coelestine";
		  choosenW = "Coelestine";
		  choosenE = "Coelestine";
		  choosenR = "Coelestine";
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
		if (enemy.Equals ("Hallaway")) {
			events ["HallawayFight"] = true;
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
			Canvas canvas = GameObject.Find ("AbilitiesUI").GetComponent<Canvas> ();
			AbilitiesUIController ui = (AbilitiesUIController)canvas.GetComponent (typeof(AbilitiesUIController));
			ui.abilitiesPoss.enabled = false;
			initializeStrings ();
			lastScene = "Load";
			currentScene = "Fort";
			paused = false;
			enemy = "";
			CompanionController comp = (CompanionController) GameObject.FindGameObjectWithTag ("Companion").GetComponent (typeof(CompanionController)); 
			comp.changeCompanion ("Coelestine");
			SceneManager.LoadScene(currentScene);
			player.SetActive(true);
			companion.SetActive(true);

		}
		if(currentScene.Equals("Beach")){
			lastScene = "Fort";
			currentScene = "Beach";
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
					player.transform.position = GameObject.Find ("BeachSpawn").transform.position;
					companion.transform.position = GameObject.Find ("BeachSpawnC").transform.position;
				}
			}
		} else {
			restorePositions ();
			enemy = "";
		}
	}
}
