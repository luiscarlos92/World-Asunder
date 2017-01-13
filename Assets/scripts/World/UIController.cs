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
			lManager.loadCombatArena (message);
		} else {
			
			string[] arr = message.Split (':');

			npcNameBox.text = arr [0];
			npcTextBox.text = arr [1];
			loadImage (arr [0]);
			messages.Remove (message);
		}
	}
}
