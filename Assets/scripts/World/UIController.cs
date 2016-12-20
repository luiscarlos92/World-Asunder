using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour {

	public Canvas dialogUI;
	public Text npcTextBox;
	public ArrayList messages;


	// Use this for initialization
	void Start () {
		npcTextBox.text = "Olá eu sou noob!";
		dialogUI.enabled = false;
		messages = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && dialogUI.isActiveAndEnabled) {
			if(messages.Count == 0){
			dialogUI.enabled = false;
			

			} else {
				string toPrint = (string)messages [0];
				if(toPrint.Equals("*trigger*")){
					messages.Remove (toPrint);
					dialogUI.enabled = false;


					GameObject.Find ("Cell Door").SetActive (false);

					GameObject.FindWithTag("Player").SetActive(false);
					GameObject.FindWithTag("Companion").SetActive(false);
					SceneManager.LoadScene("CombatArena");

					//GoToCombat
				} else {

				npcTextBox.text = toPrint;
				messages.Remove (toPrint);
				}
			}
		}		
		if ((messages.Count != 0) && !dialogUI.isActiveAndEnabled){
			string toPrint = (string)messages [0];
			npcTextBox.text = toPrint;
			messages.Remove (toPrint);
			dialogUI.enabled = true;


		}
	}

	public void addToQueue(string message){
		messages.Add (message);
	}
}
