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

	public Button buttonA;
	public Button buttonB;

	// Use this for initialization
	void Start () {
		buttonA.enabled = false;
		buttonB.enabled = false;
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

					GameObject.Find ("Poss").SetActive (false);

					Canvas canvas = GameObject.Find ("AbilitiesUI").GetComponent<Canvas> ();
					AbilitiesUIController ui = (AbilitiesUIController)canvas.GetComponent (typeof(AbilitiesUIController));
					ui.abilitiesPoss.enabled = true;
					ui.message.enabled = true;
					ui.wasPaused = false;

					canvas.enabled = true;

				}
				if (message.Equals ("Hallaway")) {
					GameObject newEnemy = Instantiate(lManager.hallawayPrefab, GameObject.Find ("CellSpawn").transform.position, this.transform.rotation) as GameObject;
					lManager.paused = false;
				}
				if (message.Equals ("ChildA")) {
					GameObject newEnemy = Instantiate(lManager.childPrefab, ((GameObject.Find ("Player").transform.position + GameObject.Find ("ChildASpawn").transform.position)/2), this.transform.rotation) as GameObject;
					Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
					UIController ui = (UIController)canvas.GetComponent (typeof(UIController));
					ui.addToQueue ("Hecte:\"Urgh, another one.\"");
					ui.addToQueue ("#trigger:Combat:Spawn1");
				}
				if (message.Equals ("ChildB")) {
					GameObject newEnemy = Instantiate(lManager.childPrefab, ((GameObject.Find ("Player").transform.position + GameObject.Find ("ChildBSpawn").transform.position)/2), this.transform.rotation) as GameObject;
					Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
					UIController ui = (UIController)canvas.GetComponent (typeof(UIController));
					if (lManager.choosenCompanion.Equals ("Poss")) {
						ui.addToQueue ("Poss:\"Well, this is the worst jig I’ve ever danced. Women can be so clingy sometimes… Huh, mate, it’s Sal Demar all over again.\"");
					}
					if (lManager.choosenCompanion.Equals ("Coelestine")) {
						ui.addToQueue ("Coelestine:\"This is not right! Whatever this is, it made the sea a mass grave. Not even a shred of dignity left for the dead!\"");
					}
					ui.addToQueue ("#trigger:Combat:Spawn2");
				}
				if (message.Equals ("Adamastor")) {
					GameObject newEnemy = Instantiate(lManager.adamastorPrefab, GameObject.Find ("AdamastorSpawn").transform.position, this.transform.rotation) as GameObject;
					Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
					UIController ui = (UIController)canvas.GetComponent (typeof(UIController));

					if (lManager.choosenCompanion.Equals ("Poss")) {
						ui.addToQueue ("Poss:\"And here it is...\"");
					}
					if (lManager.choosenCompanion.Equals ("Coelestine")) {
						ui.addToQueue ("Coelestine:\"Not good!\"");
					}

					ui.addToQueue ("Adamastor:\"I am becoming, the meat. Has rotted, rotted on bone. Bone in the fish, the fish is dust, as we become dust, the sea takes us all. \"");
					ui.addToQueue ("Adamastor:\"Foam in dreams and fog in clouds. I am becoming...\"");
					ui.addToQueue ("Adamastor:\"and you are becoming ME!\"");
					ui.addToQueue ("#trigger:Combat:Adamastor");
				}if (message.Equals ("Choice")) {
					
					Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
					UIController ui = (UIController)canvas.GetComponent (typeof(UIController));

					buttonA.enabled = true;
					buttonB.enabled = true;
					npcNameBox.enabled = false;

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

	public void clickTake(){
		Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
		UIController ui = (UIController)canvas.GetComponent (typeof(UIController));
		buttonA.enabled = false;
		buttonB.enabled = false;
		npcNameBox.enabled = true;
		ui.addToQueue ("Hecte:\"Your pain is meaningless. Know your suffering will ease the suffering of others. Become nothing!\"");
		ui.addToQueue ("#trigger:Cutscene:Adamastor1");
	}

	public void clickDontTake(){
		Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
		UIController ui = (UIController)canvas.GetComponent (typeof(UIController));
		buttonA.enabled = false;
		buttonB.enabled = false;
		npcNameBox.enabled = true;
		ui.addToQueue ("Hecte:\"After all this, you were nothing more than a man looking through glass, locked in someone else’s motions. You’re free now. Use that freedom to fix this, and maybe you’ll find absolution.\"");
		ui.addToQueue ("#trigger:Cutscene:Adamastor2");
	}


}
