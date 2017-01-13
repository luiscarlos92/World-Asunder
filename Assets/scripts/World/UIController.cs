using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour {
	public LevelManager lManager;

	public Canvas dialogUI;
	public Text npcTextBox;
	public Text npcNameBox;
	public Image npcImage;
	public ArrayList messages;


	// Use this for initialization
	void Start () {
		dialogUI.enabled = false;
		messages = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && dialogUI.isActiveAndEnabled) {
			if(messages.Count == 0){
			dialogUI.enabled = false;
			lManager.paused = false;
			} else
				processMessage ((string)messages [0]);
		}		
		if ((messages.Count != 0) && !dialogUI.isActiveAndEnabled){
			processMessage ((string)messages [0]);
			dialogUI.enabled = true;
			lManager.paused = true;
		}
	}

	public void addToQueue(string message){
		messages.Add (message);
	}

	public void loadImage(string name){
		if (name.Equals ("Hecte"))
			npcImage.sprite = Resources.Load<Sprite> ("hud/hecte");
		if (name.Equals ("Coelestine"))
			npcImage.sprite = Resources.Load<Sprite> ("hud/coelestine");
		if(name.Equals("Poss") || name.Equals("Prisoner"))
			npcImage.sprite = Resources.Load<Sprite>("hud/poss");
		if (name.Equals ("Guard"))
			npcImage.sprite = Resources.Load<Sprite> ("hud/guard");
		if(name.Equals("Adamastor"))
			npcImage.sprite = Resources.Load<Sprite>("hud/adamastor");
	}

	public void processMessage(string message){
		if(message.Contains("#trigger:")){
			messages.Remove (message);
			dialogUI.enabled = false;

			message = message.Replace("#trigger:", "");
			if (message.Contains ("Combat:")) {
				message = message.Replace("Combat:", "");
				lManager.loadCombatArena (message);
			}
			if (message.Contains ("Cutscene:")) {
				Canvas canvas = GameObject.Find ("CutsceneUI").GetComponent<Canvas> ();
				CutsceneUIController ui = (CutsceneUIController)canvas.GetComponent (typeof(CutsceneUIController));

				message = message.Replace("Cutscene:", "");
				ui.playCutscene (message);
			}
			if (message.Contains ("Action:")) {
				message = message.Replace("Action:", "");
				if(message.Equals("Poss")){
					Canvas canvas = GameObject.Find ("AbilitiesUI").GetComponent<Canvas> ();
					AbilitiesUIController ui = (AbilitiesUIController)canvas.GetComponent (typeof(AbilitiesUIController));
					ui.abilitiesPoss.enabled = true;
					ui.message.enabled = true;
					canvas.enabled = true;
				}
				if (message.Equals ("Hallaway")) {
					GameObject newEnemy = Instantiate(lManager.hallawayPrefab, GameObject.Find ("CellSpawn").transform.position, this.transform.rotation) as GameObject;
					lManager.paused = false;
				}
			}
		} else {
			
			string[] arr = message.Split (':');

			npcNameBox.text = arr [0];
			npcTextBox.text = arr [1];
			loadImage (arr [0]);
			messages.Remove (message);
		}
	}
}
