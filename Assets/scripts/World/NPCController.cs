using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using System.Collections.Generic;
using System;

public class NPCController : MonoBehaviour {

	public LevelManager lManager;
	public string name;
	public Canvas bubbleCanvas;
	public string message;
	private bool dialogSpoken = false;



	// Use this for initialization
	void Start () {
		lManager = (LevelManager)GameObject.Find ("LevelManager").GetComponent (typeof(LevelManager));
		dialogSpoken = lManager.events [name];
		bubbleCanvas.enabled = !dialogSpoken; 

		if (name.Contains ("Guard") && lManager.events ["HallawayFight"])
			gameObject.SetActive (false);
		if (name.Contains ("Poss") && lManager.events ["HallawayFight"])
			gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player") && !dialogSpoken) {

				Canvas canvas = GameObject.Find ("DialogUI").GetComponent<Canvas> ();
				UIController ui = (UIController)canvas.GetComponent (typeof(UIController));
				ui.addToQueue (message);
				bubbleCanvas.enabled = false; 

				//canvas.GetComponentInChildren<Text> ().text = message;
				dialogSpoken = true;
				lManager.events [name] = true;
		}

	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")) {
			
		}
	}
}
